using UnityEngine;
public class ShieldWindup : IState
{
    public void OnEnter(PlayerStateMachine instance)
    {
        instance.TransitionTo(System.Type.GetType("ShieldBlock"), 0.15f);
    }
    public void Tick()
    {
        UnityEngine.Debug.Log("Shield Windup");
    }

}
