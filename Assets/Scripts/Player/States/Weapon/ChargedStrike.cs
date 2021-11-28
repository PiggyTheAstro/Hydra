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
        RaycastHit hit = hitbox.Hit();
        if (hit.transform != null && canHit)
        {
            IDamageable enemy = hit.transform.GetComponent<IDamageable>();
            if (enemy != null)
            {
                enemy.OnDamage();
                canHit = false;
            }
        }
        playerMovement.Move(playerMovement.GetTransform().forward, 10f); // Overrides the movement channels to lunge
    }
}
