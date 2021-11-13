using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStrike : IState
{
    PlayerStateMachine machine;
    public void OnEnter(PlayerStateMachine instance)
    {
        instance.TransitionTo(System.Type.GetType("WeaponRecovery"), 0.22f);
        instance.movement.SetSpeed(1f);
        machine = instance;
    }
    public void Tick()
    {
        if(machine.combat.collided.Count > 0) // This reference... yuck.
        {
            for (int i = 0; i < machine.combat.collided.Count; i++)
            {
                machine.combat.collided[i].GetComponent<Rigidbody>().AddForce(Vector3.forward + Vector3.up * 10000f, ForceMode.Impulse); // Temporary OFC
                machine.combat.collided.RemoveAt(i);
            }
        }
    }
}
