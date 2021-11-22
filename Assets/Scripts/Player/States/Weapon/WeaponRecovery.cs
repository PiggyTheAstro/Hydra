using Hydra.Timers;
public class WeaponRecovery : IState
{
    public void OnEnter(IStateSwitcher instance, IPhysicsController movement)
    {
        TimerManager.singleton.StartStateMachineTimer(0.33f, typeof(IdleState));
        movement.SetMultiplier(0.6f, 0);
        movement.SetMultiplier(1f, 2);
    }
    public void Tick()
    {

    }
}
