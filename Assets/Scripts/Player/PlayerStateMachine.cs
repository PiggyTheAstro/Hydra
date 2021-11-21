using System;
using UnityEngine;
using UnityEngine.UI;
using Hydra.Timers;
public class PlayerStateMachine : MonoBehaviour, IStateSwitcher
{
    [SerializeField] private Text stateText;
    [SerializeField] private Animator animator;
    [SerializeField] private MovementManager movement;
    private IState playerState;
    private IState[] states;
    private void Start()
    {
        TimerManager.singleton.InjectMachine(this);
        states = new IState[9];
        states[0] = new IdleState();
        states[1] = new WeaponWindup();
        states[2] = new WeaponStrike();
        states[3] = new WeaponRecovery();
        states[4] = new ChargedStrike();
        states[5] = new WindupCancel();
        states[6] = new ShieldWindup();
        states[7] = new ShieldBlock();
        states[8] = new ShieldRecovery();
        ChangeState(typeof(IdleState));
    }

    private void Update()
    {
        playerState.Tick();
        stateText.text = playerState.ToString(); // Temporary
    }
    public void ChangeState(Type type)
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
    }
    public string GetCurrentState()
    {
        return playerState.ToString();
    }
}
