public class ShieldWindup : IState
{
    public void OnEnter(IStateSwitcher instance, IPhysicsController movement)
    {
        instance.TransitionTo(typeof(ShieldBlock), 0.25f);
        movement.SetSpeedMultiplier(0.4f);
        movement.SetJumpAbility(false);
        movement.SetDashAbility(false);
    }
    public void Tick()
    {

    }

}
