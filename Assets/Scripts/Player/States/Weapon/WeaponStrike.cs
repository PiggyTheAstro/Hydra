using System.Collections.Generic;
using UnityEngine;
using Hydra.Timers;
using Hydra.Hitreg;
public class WeaponStrike : IState
{
    private List<GameObject> ignored;
    private IPhysicsController playerMovement;
    private Thrust hitbox;
    public void OnEnter(IStateSwitcher instance, IPhysicsController movement)
    {
        TimerManager.singleton.StartStateMachineTimer(0.22f, typeof(WeaponRecovery));
        playerMovement = movement;
        ignored = new List<GameObject>();
        playerMovement.SetMultiplier(0f, 0);
        hitbox = new Thrust(movement.GetTransform(), 3f, 0.22f);
    }
    public void Tick()
    {
        RaycastHit hit = hitbox.Hit();
        if (hit.transform != null)
        {
            IDamageable enemy = hit.transform.GetComponent<IDamageable>();
            if (enemy != null && !ignored.Contains(hit.transform.gameObject))
            {
                enemy.OnDamage();
                ignored.Add(hit.transform.gameObject);
            }
        }
        playerMovement.Move(playerMovement.GetTransform().forward, 3f);
    }
}
