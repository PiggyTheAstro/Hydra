using UnityEngine;
public class WeaponWindup : IState
{
    PlayerStateMachine machine;
    public void OnEnter(PlayerStateMachine instance)
    {
        machine = instance;
    }
    public void Tick()
    {
        Debug.Log("Weapon Windup");
        if(!Input.GetMouseButton(0))
        {
            machine.TransitionTo(System.Type.GetType("WeaponStrike"), 0f);
        }
    }

}
