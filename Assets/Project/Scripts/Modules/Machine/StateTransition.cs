
using System;

public class StateTransition
{
    public IState Target { get; private set; }
    public Func<bool> Trigger { get; private set; }

    public StateTransition(IState target, Func<bool> trigger)
    {
        Target = target;
        Trigger = trigger;
    }
}