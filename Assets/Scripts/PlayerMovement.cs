using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float baseSpeed;
    [SerializeField] private float jumpHeight;
    private CharacterController controller;
    private float speed;
    private bool isGrounded;
    private float yVelocity;
    private bool canJump = true; // Having a "canJump" var is a bit clunky when it's only used once...
    private LayerMask layerMask;
    private bool wantsToJump;
    private void Start()
    {
        controller = GetComponent<CharacterController>(); // Should probably turn this into a rigidbody at some point
        speed = baseSpeed;
        layerMask = LayerMask.GetMask("Default");
    }
    private void Update()
    {
        isGrounded = GroundedState();
        Vector2 input = new Vector2(InputManager.singleton.HorizontalAxis, InputManager.singleton.VerticalAxis).normalized;
        Vector3 moveDir = (transform.right * input.x + transform.forward * input.y).normalized * speed;
        moveDir.y = (moveDir.y + ApplyGravity()) * baseSpeed;
        controller.Move(moveDir * Time.deltaTime); // TODO: Add movement smoothing

        if(InputManager.singleton.Jump)
        {
            wantsToJump = true;
            StartCoroutine(EndJumpTimer());
        }
        if(wantsToJump && isGrounded && canJump)
        {
            Jump();
        }
    }
    private float ApplyGravity()
    {
        if (!isGrounded)
        {
            yVelocity -= 3f * Time.deltaTime;
        }
        else if(yVelocity < 0f)
        {
            yVelocity = 0f;
        }
        return yVelocity;
    }
    private void Jump()
    {
        wantsToJump = false;
        yVelocity = jumpHeight;
    }
    private bool GroundedState()
    {
        Ray groundedRay = new Ray(transform.position, Vector3.down);
        return Physics.SphereCast(groundedRay, 0.5f, 0.6f, layerMask);
    }
    private IEnumerator EndJumpTimer()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        wantsToJump = false;
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
