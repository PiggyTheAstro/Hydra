using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStrike : IState
{
    public void OnEnter(PlayerStateMachine instance)
    {
        instance.TransitionTo(System.Type.GetType("WeaponRecovery"), 0.13f);
    }
    public void Tick()
    {
        Debug.Log("Weapon Strike");
    }
}
