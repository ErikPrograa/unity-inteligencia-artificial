
using System;

public class DecisionNode : IBehaviourNode
{
    private Func<bool> _decision;

    public DecisionNode(Func<bool> decision)
    {
        _decision = decision;
    }

    public BehaviourState Execute()
    {
        return _decision() ? BehaviourState.Success : BehaviourState.Failure;
    }
}