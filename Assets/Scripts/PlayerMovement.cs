using System.Collections;
using System.Collections.Generic; // TODO: Remove these, they're pretty damn useless anyway
using UnityEngine;
public class PlayerMovement : MonoBehaviour // I'm not sure if this being a monobehaviour is a good idea once I implement the state machine
{ 
    // Having "private" before all private vars is neater :p
    CharacterController controller;
    [SerializeField] float baseSpeed;
    float speed;
    [SerializeField] float jumpHeight;
    bool isGrounded;
    float yVelocity;
    [SerializeField] Animator spear;
    [SerializeField] Animator shield;
    bool canJump = true; // Having a "canJump" var is a bit clunky when it's only used once...

    void Start()
    {
        controller = GetComponent<CharacterController>(); // Should probably turn this into a rigidbody at some point
        yVelocity = 0f;
        speed = baseSpeed;
    }

    void Update()
    {
        isGrounded = GroundedState();
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized; // Input should be separated into a different class
        Vector3 moveDir = (transform.right * input.x + transform.forward * input.y).normalized;
        moveDir *= speed;
        moveDir.y += ApplyGravity();
        moveDir.y *= baseSpeed; // This is awkward, multiplication should be done in the ApplyGravity function
        controller.Move(moveDir * Time.deltaTime); // TODO: Add movement smoothing

        if(Input.GetKeyDown(KeyCode.Space)) // Put this into the input manager too
        {
            Jump(); // Add a delay which allows the jump to happen 0.1 seconds before the player grounds
        }
    }
    float ApplyGravity() // Use early return pattern here
    {
        if (!isGrounded)
        {
            yVelocity -= 3f * Time.deltaTime; // Move speed multiplication into this
        }
        else if(yVelocity < 0f) // Falling state?
        {
            yVelocity = 0f;
        }
        return yVelocity;
    }
    void Jump() // TODO: Early return
    {
        if (isGrounded && canJump)
        {
            yVelocity = jumpHeight;
        }
    }
    bool GroundedState()
    {
        LayerMask mask = LayerMask.GetMask("Default"); // Should not be done every frame
        if(Physics.SphereCast(transform.position, 0.5f, Vector3.down, out RaycastHit hit, 0.6f, mask)) // Am I actually going to be doing anything with "hit"?
        {
            return true;
        }
        return false;
    }
    public void SetSpeed(float multiplier)
    {
        speed = baseSpeed * multiplier;
    }
    public void SetJump(bool val)
    {
        canJump = val; // TODO: Having a setter on the jump state isn't ideal, move it into a state machine at some point
    }
}
