using UnityEngine;
public class WeaponWindup : IState
{
    PlayerStateMachine machine;
    public void OnEnter(PlayerStateMachine instance)
    {
        machine = instance;
        instance.movement.SetSpeed(0.6f);
    }
    public void Tick()
    {
        if(!Input.GetMouseButton(0))
        {
            machine.TransitionTo(System.Type.GetType("WeaponStrike"), 0f);
        }
    }

}
