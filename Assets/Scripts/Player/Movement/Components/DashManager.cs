using System.Collections;
using UnityEngine;

public class DashManager : MonoBehaviour, IMovementComponent
{
    [SerializeField] float baseDashSpeed;
    float dashSpeed;
    bool cooldownElapsed = true;
    Vector3 direction;
    
    void Start()
    {
        dashSpeed = baseDashSpeed;
    }
    void Update()
    {
        if(InputManager.singleton.Dash && cooldownElapsed)
        {
            Dash();
        }
    }
    public Vector3 MovementDirection()
    {
        return direction;
    }
    public void MultiplyIntensity(float multiplier)
    {
        dashSpeed = baseDashSpeed * multiplier;
    }
    private void Dash()
    {
        if(dashSpeed == 0f)
        {
            return;
        }
        Vector2 input = new Vector2(InputManager.singleton.HorizontalAxis, InputManager.singleton.VerticalAxis).normalized;
        Vector3 dashDir = (transform.right * input.x + transform.forward * input.y).normalized * dashSpeed;
        direction = dashDir * dashSpeed;
        cooldownElapsed = false;
        StartCoroutine(StopDash());
    }
    private IEnumerator StopDash()
    {
        yield return new WaitForSecondsRealtime(0.15f);
        direction = Vector3.zero;
        StartCoroutine(RechargeDash());
    }
    private IEnumerator RechargeDash()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        cooldownElapsed = true;
    }
}
