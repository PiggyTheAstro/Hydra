using System.Collections.Generic;
using UnityEngine;
using Hydra.Hitreg;
using Hydra.Timers;
public class ChargedStrike : IState
{
    private List<GameObject> ignored;
    private IPhysicsController playerMovement;
    private Thrust hitbox;
    public void OnEnter(IStateSwitcher instance, IPhysicsController movement)
    {
        TimerManager.singleton.StartStateMachineTimer(0.3f, typeof(WeaponRecovery));
        playerMovement = movement;
        ignored = new List<GameObject>();
        playerMovement.SetMultiplier(0f, 0);
        hitbox = new Thrust(movement.GetTransform(), 3f, 0.3f);
    }
    public void Tick()
    {

        // TODO: Remove duplication across strikes

        RaycastHit[] hit = hitbox.Hit();
        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i].transform.gameObject.tag == "Enemy" && !ignored.Contains(hit[i].transform.gameObject)) // This is temporary, damage interface will have to be implemented
            {
                hit[i].transform.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward + Vector3.up * 10000f, ForceMode.Impulse);
                ignored.Add(hit[i].transform.gameObject);
                break;
            }
        }
        playerMovement.Move(playerMovement.GetTransform().forward, 10f); // Overrides the movement channels to lunge
    }
}
