using System;
using System.Collections.Generic;
using UnityEngine;
namespace Hydra
{
    namespace Timers
    {
        public class TimerManager : MonoBehaviour
        {
            public static TimerManager singleton;
            private List<Timer> activeTimers;
            private List<StateTimer> stateMachineTimers;
            private IStateSwitcher stateMachine;
            private void Awake()
            {
                activeTimers = new List<Timer>();
                stateMachineTimers = new List<StateTimer>();
                if (singleton == null)
                {
                    singleton = this;
                }
            }
            private void Update()
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
