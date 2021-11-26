using UnityEngine;
public class PlayerMovement : IMovementComponent
{
    private const float baseSpeed = 5;
    private float speed;
    private Transform player;
    public void Init(Transform parent)
    {
        speed = baseSpeed;
        player = parent;
    }
    public void Tick()
    {

    }
    public Vector3 MovementDirection() // Simply returns the direction of the WASD input
    {
        Vector2 input = new Vector2(InputManager.singleton.HorizontalAxis, InputManager.singleton.VerticalAxis).normalized;
        Vector3 moveDir = (player.right * input.x + player.forward * input.y).normalized * speed;
        return moveDir;
    }
    public void MultiplyIntensity(float multiplier)
    {
        speed = baseSpeed * multiplier;
    }
}
