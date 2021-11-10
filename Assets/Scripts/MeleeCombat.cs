using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    [SerializeField] private Animator shieldAnimator; // Should be tied into 1 state machine
    private Animator animator;
    private List<GameObject> collided;
    private PlayerMovement movementScript;

    private void Start()
    {
        animator = GetComponent<Animator>();
        collided = new List<GameObject>();
        movementScript = GameObject.Find("Player").GetComponent<PlayerMovement>(); // This isn't ideal at all
    }
    private void Update()
    {
        if(Input.GetMouseButton(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && shieldAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) // Note to self: Please, for all that is holy, implement a state machine
        {
            animator.Play("Windup");
            movementScript.SetSpeed(0.6f);
        }
        else if(animator.GetCurrentAnimatorStateInfo(0).IsName("Windup") && !Input.GetMouseButton(0))
        {
            animator.Play("Strike");
            movementScript.SetSpeed(1.0f);
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Strike") && collided.Count > 0)
        {
            for(int i = 0; i < collided.Count; i++)
            {
                collided[i].GetComponent<Rigidbody>().AddForce(Vector3.forward + Vector3.up * 10000f, ForceMode.Impulse); // Temporary OFC
                collided.RemoveAt(i);
            } 
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag != "Enemy" || collided.Contains(col.gameObject)) // Stop checking against the name
        {
            return;
        }
        collided.Add(col.gameObject);
    }
    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag != "Enemy") // Stop checking against the name
        {
            return;
        }
        try
        {
            collided.Remove(col.gameObject);
        }
        catch
        {
            
        }
    }
}
