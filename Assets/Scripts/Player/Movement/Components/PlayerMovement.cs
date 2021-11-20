using System.Collections;
using UnityEngine;
public class PlayerMovement : MonoBehaviour, IMovementComponent
{
    [SerializeField] private float baseSpeed;
    private float speed;
    private void Start()
    {
        speed = baseSpeed;
    }
    public Vector3 MovementDirection()
    {
        Vector2 input = new Vector2(InputManager.singleton.HorizontalAxis, InputManager.singleton.VerticalAxis).normalized;
        Vector3 moveDir = (transform.right * input.x + transform.forward * input.y).normalized * speed;
        return moveDir;
    }
    public void MultiplyIntensity(float multiplier)
    {
        speed = baseSpeed * multiplier;
    }
}
