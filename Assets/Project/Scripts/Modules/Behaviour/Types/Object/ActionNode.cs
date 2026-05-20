using System;

public class ActionNode : IBehaviourNode
{
    private Func<BehaviourState> _action;

    public ActionNode(Func<BehaviourState> action)
    {
        _action = action;
    }

    public BehaviourState Execute()
    {
        return _action();
    }
}