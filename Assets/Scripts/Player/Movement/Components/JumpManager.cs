using UnityEngine;
public class JumpManager : IMovementComponent
{
    private const float baseJumpHeight = 1;
    private const float baseSpeed = 5;
    private float jumpHeight;
    private bool isGrounded;
    private float yVelocity;
    private LayerMask layerMask;
    private Transform player;
    public void Init(Transform parent)
    {
        jumpHeight = baseJumpHeight;
        layerMask = LayerMask.GetMask("Default");
        player = parent;
    }
    public void Tick()
    {
        isGrounded = GroundedState();
        if (InputManager.singleton.Jump && isGrounded)
        {
            Jump();
        }
    }
    public Vector3 MovementDirection()
    {
        return new Vector3(0f, ApplyGravity() * baseSpeed, 0f);
    }
    public void MultiplyIntensity(float multiplier)
    {
        jumpHeight = baseJumpHeight * multiplier;
    }
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
        yVelocity = jumpHeight;
    }
    private bool GroundedState()
    {
        Ray groundedRay = new Ray(player.position, Vector3.down);
        return Physics.SphereCast(groundedRay, 0.5f, 0.6f, layerMask);
    }
}
