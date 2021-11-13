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
        if(!Input.GetMouseButton(1))
        {
            machine.TransitionTo(System.Type.GetType("ShieldRecovery"), 0f);
        }
    }
}
