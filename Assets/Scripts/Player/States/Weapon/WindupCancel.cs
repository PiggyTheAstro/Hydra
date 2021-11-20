public class WindupCancel : IState
{
    public void OnEnter(IStateSwitcher instance, IPhysicsController movement)
    {
        instance.TransitionTo(typeof(IdleState), 0.4f);
        movement.SetSpeedMultiplier(0.8f);
    }
    public void Tick()
    {

    }
}
