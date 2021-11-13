using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] private Text stateText;
    private IState playerState;
    public PlayerMovement movement;
    public Animator animator;
    public MeleeCombat combat; // All 3 of these random references are weird
    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
        animator = transform.parent.GetComponent<Animator>();
        combat = GameObject.Find("Spear").GetComponent<MeleeCombat>(); // Ew
        TransitionTo(System.Type.GetType("IdleState"), 0f);
    }

    private void Update()
    {
        playerState.Tick();
        stateText.text = playerState.ToString(); // Temporary
    }

    public void TransitionTo(System.Type type, float time)
    {
        if (time == 0f)
        {
            playerState = System.Activator.CreateInstance(type) as IState; // A new state shouldn't be created every single time
            playerState.OnEnter(this);
            animator.Play(type.ToString());
            return;
        }
        else
        {
            StartCoroutine(TransitionDelay(type, time));
        }

    }
    private IEnumerator TransitionDelay(System.Type type, float time)
    {
        yield return new WaitForSecondsRealtime(time);
        TransitionTo(type, 0f);
    }
    public string GetCurrentState()
    {
        return playerState.ToString();
    }
}
