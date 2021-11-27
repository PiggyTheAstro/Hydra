using System;
namespace Hydra
{
    namespace Timers
    {
        public class Timer // Base timer
        {
            public Timer()
            {

            }
            public Timer(float timerTime, Action action)
            {
                function = action;
                time = timerTime;
                elapsedTime = 0f;
            }
            protected float time;
            protected float elapsedTime;
            protected Action function;

            public float Time { get => time; }
            public float ElapsedTime { get => elapsedTime; set => elapsedTime = value; }
            public Action Function { get => function; }
        }
    }
}
