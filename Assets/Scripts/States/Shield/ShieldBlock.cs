using UnityEngine;

public class ShieldBlock : IState
{
    private PlayerStateMachine machine;
    public void OnEnter(PlayerStateMachine instance)
    {
        machine = instance;
    }
    public void Tick()
    {
        if(!InputManager.singleton.Block)
        {
            machine.TransitionTo(System.Type.GetType("ShieldRecovery"), 0f);
        }
    }
}
