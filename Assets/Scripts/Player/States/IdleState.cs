public class IdleState : IState
{
    private IStateSwitcher machine;
    public void OnEnter(IStateSwitcher instance, IPhysicsController movement)
    {
        machine = instance;
        movement.SetMultiplier(1f, 0);
        movement.SetMultiplier(1f, 1);
        movement.SetMultiplier(1f, 2);
    }
    public void Tick()
    {
        if (InputManager.singleton.Attack)
        {
            machine.ChangeState(typeof(WeaponWindup));
        }
        else if (InputManager.singleton.Block)
        {
            machine.ChangeState(typeof(ShieldWindup));
        }
    }

}
