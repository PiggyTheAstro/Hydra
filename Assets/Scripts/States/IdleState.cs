using UnityEngine;
public class IdleState : IState
{
    private PlayerStateMachine machine;
    public void OnEnter(PlayerStateMachine instance)
    {
        machine = instance;
    }
    public void Tick()
    {
        if(InputManager.singleton.Attack)
        {
            machine.TransitionTo(System.Type.GetType("WeaponWindup"), 0f);
        }
        else if(InputManager.singleton.Block)
        {
            machine.TransitionTo(System.Type.GetType("ShieldWindup"), 0f);
        }
    }

}
