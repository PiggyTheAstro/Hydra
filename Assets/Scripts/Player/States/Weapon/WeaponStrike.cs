using System.Collections.Generic;
using UnityEngine;

public class WeaponStrike : IState
{
    private List<GameObject> ignored;
    private IPhysicsController playerMovement;
    public void OnEnter(IStateSwitcher instance, IPhysicsController movement)
    {
        instance.TransitionTo(typeof(WeaponRecovery), 0.22f);
        playerMovement = movement;
        ignored = new List<GameObject>();
        playerMovement.SetMultiplier(1f, 0);
    }
    public void Tick()
    {
        // Remove duplicate ASAP

        RaycastHit[] hit = Physics.SphereCastAll(playerMovement.GetTransform().position, 0.15f, playerMovement.GetTransform().forward, 3.2f);
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
