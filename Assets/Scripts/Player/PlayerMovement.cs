using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour, IPhysicsController
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
    private bool isDashing;
    private bool canDash = true;
    private bool cooldownElapsed = true;
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
        if (!isDashing)
        {
            controller.Move(moveDir * Time.deltaTime); // TODO: Add movement smoothing
        }
        else
        {
            Vector3 dashDir = new Vector3(moveDir.x, 0f, moveDir.z).normalized * (baseSpeed * 3.5f);
            dashDir.y = moveDir.y;
            controller.Move(dashDir * Time.deltaTime);
        }
        if(InputManager.singleton.Dash && canDash && cooldownElapsed)
        {
            Dash();
        }
        if (InputManager.singleton.Jump)
        {
            wantsToJump = true;
            StartCoroutine(EndJumpTimer());
        }
        if (wantsToJump && isGrounded && canJump)
        {
            Jump();
        }
    }
    // The following is jumping/gravity
    private float ApplyGravity()
    {
        if (!isGrounded)
        {
            yVelocity -= 3f * Time.deltaTime;
        }
        else if (yVelocity < 0f)
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
    // The following is the dash
    
    private void Dash()
    {
        isDashing = true;
        cooldownElapsed = false;
        StartCoroutine(StopDash());
        StartCoroutine(DashCooldown());
    }
    private IEnumerator StopDash()
    {
        yield return new WaitForSecondsRealtime(0.15f);
        isDashing = false;
    }
    private IEnumerator DashCooldown()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        cooldownElapsed = true;
    }
    // The following are functions from the interface
    public void SetSpeedMultiplier(float multiplier)
    {
        speed = baseSpeed * multiplier;
    }
    public void SetJumpAbility(bool val)
    {
        canJump = val;
    }
    public Transform GetTransform()
    {
        return transform;
    }
    public void Move(Vector3 dir, float speed)
    {
        controller.Move(dir * speed * Time.deltaTime);
    }
    public void SetDashAbility(bool val)
    {
        canDash = val;
    }
}
