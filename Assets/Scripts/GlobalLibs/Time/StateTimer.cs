using System;
namespace Hydra
{
    namespace Timers
    {
        public class StateTimer : Timer // Timer for switching between state machine states
        {
            private Type type;
            public StateTimer(float timerTime, Type parameter)
            {
                time = timerTime;
                elapsedTime = 0;
                type = parameter;
            }
            public Type Param { get => type; }
        }
    }
}
