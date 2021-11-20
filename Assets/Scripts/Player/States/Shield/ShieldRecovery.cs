public class ShieldRecovery : IState
{

    public void OnEnter(IStateSwitcher instance, IPhysicsController movement)
    {
        instance.TransitionTo(typeof(IdleState), 0.17f);
        movement.SetMultiplier(1f, 0);
    }
    public void Tick()
    {

    }
}
