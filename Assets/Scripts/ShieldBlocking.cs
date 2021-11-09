using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBlocking : MonoBehaviour
{
    Animator shieldAnimator;
    [SerializeField] Animator spearAnimator;
    PlayerMovement movementScript;
    // Start is called before the first frame update
    void Start()
    {
        shieldAnimator = GetComponent<Animator>();
        movementScript = GameObject.Find("Player").GetComponent<PlayerMovement>(); // Not ideal
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1) && shieldAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && spearAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) // Please make a state machine already
        {
            shieldAnimator.Play("ShieldWindup");
            movementScript.SetSpeed(0.4f);
            movementScript.SetJump(false);
        }
        else if(!Input.GetMouseButton(1) && shieldAnimator.GetCurrentAnimatorStateInfo(0).IsName("Block"))
        {
            shieldAnimator.Play("ShieldDown");
            movementScript.SetSpeed(1f);
            movementScript.SetJump(true); // TODO: This entire SetJump thing is weird, come up with another solution
        }
    }
}
