public class ShieldRecovery : IState
{

    public void OnEnter(IStateSwitcher instance, IPhysicsController movement)
    {
        instance.TransitionTo(typeof(IdleState), 0.17f);
        movement.SetSpeedMultiplier(1f);
        movement.SetJumpAbility(true);
    }
    public void Tick()
    {

    }
}
