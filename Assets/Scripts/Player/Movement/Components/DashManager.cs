using Hydra.Timers;
using UnityEngine;
public class DashManager : IMovementComponent
{
    private const float baseDashSpeed = 3.5f;
    private float dashSpeed;
    private bool cooldownElapsed = true;
    private Vector3 direction;
    private Transform player;
    public void Init(Transform parent)
    {
        dashSpeed = baseDashSpeed;
        player = parent;
    }
    public void Tick()
    {
        if (InputManager.singleton.Dash && cooldownElapsed)
        {
            Dash();
        }
    }
    public Vector3 MovementDirection()
    {
        return direction;
    }
    public void MultiplyIntensity(float multiplier) // Multiplier affects dash speed
    {
        dashSpeed = baseDashSpeed * multiplier;
    }
    private void Dash() // Dashes in the input direction for 0.15 seconds
    {
        if (dashSpeed == 0f)
        {
            return;
        }
        Vector2 input = new Vector2(InputManager.singleton.HorizontalAxis, InputManager.singleton.VerticalAxis).normalized;
        Vector3 dashDir = (player.right * input.x + player.forward * input.y).normalized * dashSpeed;
        direction = dashDir * dashSpeed;
        cooldownElapsed = false;
        TimerManager.singleton.StartTimer(0.15f, StopDash);
    }
    private void StopDash() // Dash cooldown is 1.5 for now, to be made adjustable later
    {
        direction = Vector3.zero;
        TimerManager.singleton.StartTimer(1.5f, RechargeDash);
    }
    private void RechargeDash()
    {
        cooldownElapsed = true;
    }
}
