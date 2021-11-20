public class WeaponRecovery : IState
{
    public void OnEnter(IStateSwitcher instance, IPhysicsController movement)
    {
        instance.TransitionTo(typeof(IdleState), 0.33f);
        movement.SetMultiplier(0.6f, 0);
    }
    public void Tick()
    {

    }
}
