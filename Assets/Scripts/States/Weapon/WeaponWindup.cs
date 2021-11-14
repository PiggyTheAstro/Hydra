using UnityEngine;
public class WeaponWindup : IState
{
    private IStateSwitcher machine;
    public void OnEnter(IStateSwitcher instance, IPhysicsController movement)
    {
        machine = instance;
        movement.SetSpeedMultiplier(0.6f);
    }
    public void Tick()
    {
        if(!InputManager.singleton.Attack)
        {
            machine.TransitionTo(typeof(WeaponStrike), 0f);
        }
    }

}
