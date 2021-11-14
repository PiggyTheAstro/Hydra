using UnityEngine;

public class ShieldBlock : IState
{
    private IStateSwitcher machine;
    public void OnEnter(IStateSwitcher instance, IPhysicsController movement)
    {
        machine = instance;
    }
    public void Tick()
    {
        if(!InputManager.singleton.Block)
        {
            machine.TransitionTo(typeof(ShieldRecovery), 0f);
        }
    }
}
