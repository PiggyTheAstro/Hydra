public interface IState
{
    void OnEnter(IStateSwitcher instance, IPhysicsController movement);
    void Tick();
}
