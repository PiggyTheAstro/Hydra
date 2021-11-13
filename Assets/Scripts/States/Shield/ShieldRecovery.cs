public class ShieldRecovery : IState
{

    public void OnEnter(PlayerStateMachine instance)
    {
        instance.TransitionTo(System.Type.GetType("IdleState"), 0.17f);
        instance.movement.SetSpeed(1f);
        instance.movement.SetJump(true);
    }
    public void Tick()
    {

    }
}
