using UnityEngine;


public abstract class ActionComponentNode : MonoBehaviour, IBehaviourNode
{
    private IBehaviourNode _node;

    protected virtual void Awake()
    {
        _node = new ActionNode(Action);
    }

    public BehaviourState Execute()
    {
        return _node.Execute();
    }

    protected abstract BehaviourState Action();
}