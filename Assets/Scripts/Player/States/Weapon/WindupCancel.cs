using Hydra.Timers;
public class WindupCancel : IState
{
    public void OnEnter(IStateSwitcher instance, IPhysicsController movement)
    {
        TimerManager.singleton.StartStateMachineTimer(0.4f, typeof(IdleState));
        movement.SetMultiplier(0.8f, 0);
        movement.SetMultiplier(1f, 2);
    }
    public void Tick()
    {

    }
}
