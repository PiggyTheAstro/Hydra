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
        layerMask = LayerMask.GetMask("Default"); // A layermask must be made for collision between the grounded ray and the player's shield to not occur
        player = parent;
    }
    public void Tick()
    {
        isGrounded = GroundedState(); // Grounded check happens every tick
        if (InputManager.singleton.Jump && isGrounded)
        {
            Jump();
        }
    }
    public Vector3 MovementDirection()
    {
        return new Vector3(0f, ApplyGravity() * baseSpeed, 0f);
    }
    public void MultiplyIntensity(float multiplier) // Component multiplier affects jump height here
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
    private bool GroundedState() // Spherecast used to determine if the player is grounded
    {
        Ray groundedRay = new Ray(player.position, Vector3.down);
        return Physics.SphereCast(groundedRay, 0.5f, 0.6f, layerMask);
    }
}
