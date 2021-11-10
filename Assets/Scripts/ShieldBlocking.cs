using UnityEngine;

public class ShieldBlocking : MonoBehaviour
{
    [SerializeField] private Animator spearAnimator; // Should be merged
    private Animator shieldAnimator;
    private PlayerMovement movementScript;

    private void Start()
    {
        shieldAnimator = GetComponent<Animator>();
        movementScript = GameObject.Find("Player").GetComponent<PlayerMovement>(); // Not ideal
    }
    private void Update()
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
