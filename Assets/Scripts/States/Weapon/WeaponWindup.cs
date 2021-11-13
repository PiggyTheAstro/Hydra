using UnityEngine;
public class WeaponWindup : IState
{
    private PlayerStateMachine machine;
    public void OnEnter(PlayerStateMachine instance)
    {
        machine = instance;
        instance.movement.SetSpeed(0.6f);
    }
    public void Tick()
    {
        if(!InputManager.singleton.Attack)
        {
            machine.TransitionTo(System.Type.GetType("WeaponStrike"), 0f);
        }
    }

}
