public class ShieldWindup : IState
{
    public void OnEnter(PlayerStateMachine instance)
    {
        instance.TransitionTo(System.Type.GetType("ShieldBlock"), 0.25f);
        instance.movement.SetSpeed(0.4f);
        instance.movement.SetJump(false);
    }
    public void Tick()
    {

    }

}
