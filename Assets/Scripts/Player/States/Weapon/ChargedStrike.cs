using Hydra.Hitreg;
using Hydra.Timers;
using UnityEngine;
public class ChargedStrike : IState
{
    private bool canHit;
    private IPhysicsController playerMovement;
    private Thrust hitbox;
    public void OnEnter(IStateSwitcher instance, IPhysicsController movement)
    {
        TimerManager.singleton.StartStateMachineTimer(0.3f, typeof(WeaponRecovery));
        playerMovement = movement;
        playerMovement.SetMultiplier(0f, 0);
        hitbox = new Thrust(movement.GetTransform(), 3f, 0.3f);
        canHit = true;
    }
    public void Tick()
    {
        playerMovement.Move(playerMovement.GetTransform().forward, 5f); // Lunging is split up into 2 parts, so that it slows down after a hit
        if (!canHit)
        {
            return;
        }
        RaycastHit hit = hitbox.Hit();
        if (hit.transform != null)
        {
            IDamageable enemy = hit.transform.root.GetComponent<IDamageable>();
            if (enemy != null)
            {
                HitInfo hitInfo = new HitInfo(playerMovement.GetTransform().forward, 10f);
                enemy.OnDamage(hitInfo);
                canHit = false;
                TimerManager.singleton.Pause(0.15f);
            }
        }
        playerMovement.Move(playerMovement.GetTransform().forward, 5f); // Overrides the movement channels to lunge
    }
}
