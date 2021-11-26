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
            private List<StateTimer> stateMachineTimers;
            private IStateSwitcher stateMachine;
            private void Awake()
            {
                activeTimers = new List<Timer>();
                stateMachineTimers = new List<StateTimer>();
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
                        activeTimers[i].Function();
                        activeTimers.RemoveAt(i);
                    }
                }
                for (int i = 0; i < stateMachineTimers.Count; i++)
                {
                    stateMachineTimers[i].ElapsedTime += Time.deltaTime;
                    if (stateMachineTimers[i].Time <= stateMachineTimers[i].ElapsedTime)
                    {
                        stateMachine.ChangeState(stateMachineTimers[i].Param);
                        stateMachineTimers.RemoveAt(i);
                    }
                }
            }
            public void StartTimer(float time, Action func)
            {
                activeTimers.Add(new Timer(time, func));
            }
            public void StartStateMachineTimer(float time, Type param)
            {
                stateMachineTimers.Add(new StateTimer(time, param));
            }
            public void InjectMachine(IStateSwitcher machine)
            {
                stateMachine = machine;
            }
        }
    }
}
