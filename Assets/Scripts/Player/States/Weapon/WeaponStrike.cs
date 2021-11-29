using Hydra.Hitreg;
using Hydra.Timers;
using UnityEngine;
public class WeaponStrike : IState
{
    private bool canHit;
    private IPhysicsController playerMovement;
    private Thrust hitbox;
    public void OnEnter(IStateSwitcher instance, IPhysicsController movement)
    {
        TimerManager.singleton.StartStateMachineTimer(0.22f, typeof(WeaponRecovery));
        playerMovement = movement;
        playerMovement.SetMultiplier(0f, 0);
        hitbox = new Thrust(movement.GetTransform(), 3f, 0.22f);
        canHit = true;
    }
    public void Tick()
    {
        if(!canHit)
        {
            return;
        }
        RaycastHit hit = hitbox.Hit();
        if (hit.transform != null)
        {
            IDamageable enemy = hit.transform.root.GetComponent<IDamageable>();
            if (enemy != null)
            {
                HitInfo hitInfo = new HitInfo(playerMovement.GetTransform().forward, 5f);
                enemy.OnDamage(hitInfo);
                canHit = false;
            }
        }
        playerMovement.Move(playerMovement.GetTransform().forward, 3f);
    }
}
