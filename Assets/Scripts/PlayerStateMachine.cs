using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerStateMachine : MonoBehaviour
{
    IState playerState;
    void Start()
    {
        playerState = new IdleState();
        playerState.OnEnter(this);
    }

    void Update()
    {
        playerState.Tick();
    }
    public void TransitionTo(System.Type type, float time)
    {
        if (time == 0f)
        {
            playerState = System.Activator.CreateInstance(type) as IState;
            playerState.OnEnter(this);
            return;
        }
        else
        {
            StartCoroutine(TransitionDelay(type, time));
        }

    }
    IEnumerator TransitionDelay(System.Type type, float time)
    {
        yield return new WaitForSecondsRealtime(time);
        TransitionTo(type, 0f);
    }
}
