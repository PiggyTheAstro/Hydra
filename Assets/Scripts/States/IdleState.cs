using UnityEngine;
public class IdleState : IState
{
    PlayerStateMachine machine;
    public void OnEnter(PlayerStateMachine instance)
    {
        machine = instance;
    }
    public void Tick()
    {
        Debug.Log("Idle");
        if(Input.GetMouseButtonDown(0))
        {
            machine.TransitionTo(System.Type.GetType("WeaponWindup"), 0f);
        }
        else if(Input.GetMouseButtonDown(1))
        {
            machine.TransitionTo(System.Type.GetType("ShieldWindup"), 0f);
        }
    }

}
