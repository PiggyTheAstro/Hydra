public class ShieldBlock : IState
{
    private IStateSwitcher machine;
    public void OnEnter(IStateSwitcher instance, IPhysicsController movement)
    {
        machine = instance;
        movement.SetMultiplier(0.3f, 0);
    }
    public void Tick()
    {
        if (!InputManager.singleton.Block)
        {
            machine.ChangeState(typeof(ShieldRecovery));
        }
    }
}
