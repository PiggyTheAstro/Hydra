using Hydra.Timers;
public class ShieldRecovery : IState
{

    public void OnEnter(IStateSwitcher instance, IPhysicsController movement)
    {
        TimerManager.singleton.StartStateMachineTimer(0.25f, typeof(IdleState));
        movement.SetMultiplier(1f, 0);
    }
    public void Tick()
    {

    }
}
