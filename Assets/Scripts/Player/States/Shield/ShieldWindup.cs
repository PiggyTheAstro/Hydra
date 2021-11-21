using Hydra.Timers;
public class ShieldWindup : IState
{
    public void OnEnter(IStateSwitcher instance, IPhysicsController movement)
    {
        TimerManager.singleton.StartStateMachineTimer(0.25f, typeof(ShieldBlock));
        movement.SetMultiplier(0.4f, 0);
        movement.SetMultiplier(0f, 1);
        movement.SetMultiplier(0.7f, 2);
    }
    public void Tick()
    {

    }

}
