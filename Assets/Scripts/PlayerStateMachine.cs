using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerStateMachine : MonoBehaviour, IStateSwitcher
{
    [SerializeField] private Text stateText;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement movement;
    private IState playerState;
    private IState[] states;
    private void Start()
    {
        states = new IState[7];
        states[0] = new IdleState();
        states[1] = new WeaponWindup();
        states[2] = new WeaponStrike();
        states[3] = new WeaponRecovery();
        states[4] = new ShieldWindup();
        states[5] = new ShieldBlock();
        states[6] = new ShieldRecovery();
        TransitionTo(typeof(IdleState), 0f);
    }

    private void Update()
    {
        playerState.Tick();
        stateText.text = playerState.ToString(); // Temporary
    }

    public void TransitionTo(Type type, float time)
    {
        if (time == 0f)
        {
            for (int i = 0; i < states.Length; i++)
            {
                if (type == states[i].GetType())
                {
                    playerState = states[i];
                }
            }
            playerState.OnEnter(this, movement);
            animator.Play(type.ToString());
            return;
        }
        else
        {
            StartCoroutine(TransitionDelay(type, time));
        }

    }
    private IEnumerator TransitionDelay(Type type, float time)
    {
        yield return new WaitForSecondsRealtime(time);
        TransitionTo(type, 0f);
    }
    public string GetCurrentState()
    {
        return playerState.ToString();
    }
}
