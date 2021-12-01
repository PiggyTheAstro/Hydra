using System;
using System.Collections.Generic;
using UnityEngine;
namespace Hydra
{
    namespace Timers
    {
        public class TimerManager : MonoBehaviour // TODO: Run timers on another thread
        {
            public static TimerManager singleton;
            private List<Timer> activeTimers;
            private List<Timer> unscaledTimers;
            [SerializeField] private PlayerStateMachine stateMachine;
            private void Start()
            {
                activeTimers = new List<Timer>();
                unscaledTimers = new List<Timer>();
                if (singleton == null) // TODO: Make it carry over multiple scenes
                {
                    singleton = this;
                }
            }
            private void Update() // Since it utilizes deltaTime, this timer system will always be frame-accurate and not cause garbage
            {
                for (int i = 0; i < activeTimers.Count; i++)
                {
                    activeTimers[i].ElapsedTime += Time.deltaTime;
                    if (activeTimers[i].Time <= activeTimers[i].ElapsedTime)
                    {
                        if (activeTimers[i] is StateTimer)
                        {
                            stateMachine.ChangeState((activeTimers[i] as StateTimer).Param);
                            activeTimers.RemoveAt(i);
                            continue;
                        }
                        activeTimers[i].Function();
                        activeTimers.RemoveAt(i);
                    }
                }
                for(int i = 0; i < unscaledTimers.Count; i++)
                {
                    unscaledTimers[i].ElapsedTime += Time.unscaledDeltaTime;
                    if(unscaledTimers[i].Time <= unscaledTimers[i].ElapsedTime)
                    {
                        unscaledTimers[i].Function();
                        unscaledTimers.RemoveAt(i);
                    }
                }
            }
            public void StartTimer(float time, Action func)
            {
                activeTimers.Add(new Timer(time, func));
            }
            public void StartStateMachineTimer(float time, Type param)
            {
                activeTimers.Add(new StateTimer(time, param));
            }
            public void StartUnscaledTimer(float time, Action func) // This timer will run even when the game is paused
            {
                unscaledTimers.Add(new Timer(time, func));
            }
            public void Pause(float pauseTime)
            {
                StartUnscaledTimer(pauseTime, Unpause);
                Time.timeScale = 0f;
            }
            public void Unpause()
            {
                Time.timeScale = 1f;
            }
        }
    }
}
