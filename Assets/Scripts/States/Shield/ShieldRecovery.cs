using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRecovery : IState
{

    public void OnEnter(PlayerStateMachine instance)
    {
        instance.TransitionTo(System.Type.GetType("IdleState"), 0.1f);
    }
    public void Tick()
    {
        Debug.Log("Shield Recovery");
    }
}
