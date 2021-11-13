using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecovery : IState
{
    public void OnEnter(PlayerStateMachine instance)
    {
        instance.TransitionTo(System.Type.GetType("IdleState"), 0.2f);
    }
    public void Tick()
    {
        Debug.Log("Weapon Recovery");
    }
}
