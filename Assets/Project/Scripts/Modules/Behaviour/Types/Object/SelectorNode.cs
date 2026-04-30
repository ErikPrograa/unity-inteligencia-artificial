
using System.Collections.Generic;

public class SelectorNode : IBehaviourNode
{
    private List<IBehaviourNode> _children;

    public SelectorNode(List<IBehaviourNode> children)
    {
        _children = children;
    }

    public BehaviourState Execute()
    {
        foreach(var child in _children)
        {
            BehaviourState state = child.Execute();

            if(state == BehaviourState.Success)
                return BehaviourState.Success;

            if(state == BehaviourState.Running)
                return BehaviourState.Running;
        }

        return BehaviourState.Failure;
    }
}