using UnityEngine;

public class SelectorComponentNode : MonoBehaviour, IBehaviourNode
{
    [SerializeField] private MonoBehaviour[] children;

    private IBehaviourNode _node;

    protected virtual void Awake()
    {
        var ch = new IBehaviourNode[children.Length];
        for (int i = 0; i < children.Length; i++)
            ch[i] = children[i].GetComponent<IBehaviourNode>();

        _node = new SelectorNode(new(ch));
    }

    public BehaviourState Execute()
    {
        return _node.Execute(); 
    }
}