using System;
using UnityEngine;
using UnityEngine.UI;
using Hydra.Timers;
public class PlayerStateMachine : MonoBehaviour, IStateSwitcher
{
    [SerializeField] private Text stateText;
    [SerializeField] private Animator animator;
    [SerializeField] private MovementManager movement;
    [SerializeField] private string[] serializedStates;
    private IState playerState;
    private IState[] states;
    private void Start()
    {
        states = new IState[9];
        for(int i = 0; i < states.Length; i++)
        {
            var stateObj = Activator.CreateInstance(Type.GetType(serializedStates[i]));
            states[i] = stateObj as IState;
            
        }
        ChangeState(states[0].GetType());
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
