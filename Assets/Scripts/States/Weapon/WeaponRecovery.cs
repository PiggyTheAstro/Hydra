public class WeaponRecovery : IState
{
    public void OnEnter(IStateSwitcher instance, IPhysicsController movement)
    {
        instance.TransitionTo(typeof(IdleState), 0.33f);
    }
    public void Tick()
    {

    }
}
