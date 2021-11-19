using UnityEngine;
public class IdleState : IState
{
    private IStateSwitcher machine;
    public void OnEnter(IStateSwitcher instance, IPhysicsController movement)
    {
        machine = instance;
    }
    public void Tick()
    {
        if(InputManager.singleton.Attack)
        {
            machine.TransitionTo(typeof(WeaponWindup), 0f);
        }
        else if(InputManager.singleton.Block)
        {
            machine.TransitionTo(typeof(ShieldWindup), 0f);
        }
    }

}
