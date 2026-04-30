using UnityEngine;

public abstract class DecisionComponentNode : MonoBehaviour, IBehaviourNode
{
    private IBehaviourNode _node;

    protected virtual void Awake()
    {
        _node = new DecisionNode(Decision);
    }

    public BehaviourState Execute()
    {
        return _node.Execute();
    }

    protected abstract bool Decision();
}