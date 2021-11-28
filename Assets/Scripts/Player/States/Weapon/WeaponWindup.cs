using System;
using UnityEngine;
public class WeaponWindup : IState
{
    private IStateSwitcher machine;
    private float chargeTime;
    private Type attackType;
    public void OnEnter(IStateSwitcher instance, IPhysicsController movement)
    {
        attackType = typeof(WeaponStrike);
        chargeTime = 0;
        machine = instance;
        movement.SetMultiplier(0.6f, 0);
        movement.SetMultiplier(0f, 2);
    }
    public void Tick()
    {
        chargeTime += Time.deltaTime;
        if (chargeTime >= 0.5f)
        {
            attackType = typeof(ChargedStrike);
            chargeTime = 0.5f;
            if (InputManager.singleton.Block)
            {
                machine.ChangeState(typeof(WindupCancel));
            }
        }
        if (!InputManager.singleton.Attack)
        {
            machine.ChangeState(attackType);
        }
    }

}
