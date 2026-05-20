using System.Collections.Generic;

public class SequenceNode : IBehaviourNode
{
    private List<IBehaviourNode> _children;
    private int _current;

    public SequenceNode(List<IBehaviourNode> children)
    {
        _children = children;
    }

    public BehaviourState Execute()
    {
        for(; _current<_children.Count; _current++)
        {
            BehaviourState state = _children[_current].Execute();

            if(state == BehaviourState.Running)
                return BehaviourState.Running;

            if(state == BehaviourState.Failure)
            {
                _current = 0;
                return BehaviourState.Failure;
            }
        }

        _current = 0;
        return BehaviourState.Success;
    }
}