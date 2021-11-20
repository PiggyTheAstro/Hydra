using UnityEngine;
public class WeaponWindup : IState
{
    private IStateSwitcher machine;
    float chargeTime;
    bool charged;
    public void OnEnter(IStateSwitcher instance, IPhysicsController movement)
    {
        charged = false;
        chargeTime = 0;
        machine = instance;
        movement.SetSpeedMultiplier(0.6f);
        movement.SetDashAbility(false);
    }
    public void Tick()
    {
        if (!charged)
        {
            chargeTime += Time.deltaTime;
            if(!InputManager.singleton.Attack)
            {
                machine.TransitionTo(typeof(WeaponStrike), 0f);
            }
        }
        else
        {
            if (InputManager.singleton.Block)
            {
                machine.TransitionTo(typeof(WindupCancel), 0f);
            }
            if(!InputManager.singleton.Attack)
            {
                machine.TransitionTo(typeof(ChargedStrike), 0f);
            }
        }
        if(chargeTime > 0.5)
        {
            charged = true;
        }
    }

}
