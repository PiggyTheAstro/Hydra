using Hydra.Parsing;
using System;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStateMachine : MonoBehaviour, IStateSwitcher
{
    [SerializeField] private Animator animator;
    [SerializeField] private MovementManager movement;
    [SerializeField] private string[] serializedStates;
    private IState playerState;
    private IState[] states;
    private void Start()
    {
        states = new IState[9];
        for (int i = 0; i < states.Length; i++)
        {
            states[i] = StringParser.instance.StringToInstance(serializedStates[i]) as IState;
        }
        ChangeState(states[0].GetType());
    }

    private void Update()
    {
        playerState.Tick();
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
