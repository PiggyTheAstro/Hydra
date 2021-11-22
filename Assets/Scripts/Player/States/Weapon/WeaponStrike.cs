using System.Collections.Generic;
using UnityEngine;
using Hydra.Timers;
using Hydra.Hitreg;
public class WeaponStrike : IState
{
    private List<GameObject> ignored;
    private IPhysicsController playerMovement;
    private Thrust hitbox;
    public void OnEnter(IStateSwitcher instance, IPhysicsController movement)
    {
        TimerManager.singleton.StartStateMachineTimer(0.22f, typeof(WeaponRecovery));
        playerMovement = movement;
        ignored = new List<GameObject>();
        playerMovement.SetMultiplier(0f, 0);
        hitbox = new Thrust(movement.GetTransform(), 3f, 0.22f);
    }
    public void Tick()
    {
        // Remove duplicate ASAP
        // I know this is awful, don't comment
        RaycastHit[] hit = hitbox.Hit();
        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i].transform.gameObject.tag == "Enemy" && !ignored.Contains(hit[i].transform.gameObject))
            {
                hit[i].transform.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward + Vector3.up * 10000f, ForceMode.Impulse);
                ignored.Add(hit[i].transform.gameObject);
                break;
            }
        }
        playerMovement.Move(playerMovement.GetTransform().forward, 3f);
    }
}
