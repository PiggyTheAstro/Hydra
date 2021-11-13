public class WeaponRecovery : IState
{
    public void OnEnter(PlayerStateMachine instance)
    {
        instance.TransitionTo(System.Type.GetType("IdleState"), 0.33f);
    }
    public void Tick()
    {

    }
}
