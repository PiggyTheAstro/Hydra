using UnityEngine;
public class WeaponWindup : IState
{
    private IStateSwitcher machine;
    float chargeTime;
    bool charged;
    public void OnEnter(IStateSwitcher instance, IPhysicsController movement)
    {
        chargeTime = 0;
        charged = false;
        machine = instance;
        movement.SetMultiplier(0.6f, 0);
        movement.SetMultiplier(0f, 2);
    }
    public void Tick()
    {
        chargeTime += Time.deltaTime;
        if (chargeTime > 0.5f)
        {
            charged = true;
            chargeTime = 0.5f;
        }
        
        if (!charged)
        {
            if (!InputManager.singleton.Attack)
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
            if (!InputManager.singleton.Attack)
            {
                machine.TransitionTo(typeof(ChargedStrike), 0f);
            }
        }
    }

}
