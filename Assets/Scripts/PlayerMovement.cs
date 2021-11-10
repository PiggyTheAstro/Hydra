using UnityEngine;
public class PlayerMovement : MonoBehaviour // I'm not sure if this being a monobehaviour is a good idea once I implement the state machine
{
    [SerializeField] private float baseSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private Animator spear; // Weird dependencies
    [SerializeField] private Animator shield;
    private CharacterController controller;
    private float speed;
    private bool isGrounded;
    private float yVelocity;
    private bool canJump = true; // Having a "canJump" var is a bit clunky when it's only used once...
    private LayerMask layerMask;

    private void Start()
    {
        controller = GetComponent<CharacterController>(); // Should probably turn this into a rigidbody at some point
        speed = baseSpeed;
        layerMask = LayerMask.GetMask("Default");
    }
    private void Update()
    {
        isGrounded = GroundedState();
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized; // Input should be separated into a different class
        Vector3 moveDir = (transform.right * input.x + transform.forward * input.y).normalized * speed;
        moveDir.y = (moveDir.y + ApplyGravity()) * baseSpeed;
        controller.Move(moveDir * Time.deltaTime); // TODO: Add movement smoothing

        if(Input.GetKeyDown(KeyCode.Space)) // Put this into the input manager too
        {
            Jump(); // Add a delay which allows the jump to happen 0.1 seconds before the player grounds
        }
    }
    private float ApplyGravity()
    {
        if (!isGrounded)
        {
            yVelocity -= 3f * Time.deltaTime;
        }
        else if(yVelocity < 0f) // Falling state?
        {
            yVelocity = 0f;
        }
        return yVelocity;
    }
    private void Jump()
    {
        if(!isGrounded || !canJump)
        {
            return;
        }
        yVelocity = jumpHeight;
    }
    private bool GroundedState()
    {
        Ray groundedRay = new Ray(transform.position, Vector3.down);
        return Physics.SphereCast(groundedRay, 0.5f, 0.6f, layerMask);
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
