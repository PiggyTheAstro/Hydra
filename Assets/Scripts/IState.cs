public interface IState
{
    void OnEnter(PlayerStateMachine instance);
    void Tick();
}
