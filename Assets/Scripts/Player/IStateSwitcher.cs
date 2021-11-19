using System;
public interface IStateSwitcher
{
    void TransitionTo(Type type, float time);
}
