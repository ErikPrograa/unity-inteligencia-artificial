using UnityEngine;
using UnityEngine.AI;

public class SoldierController : MonoBehaviour
{
    [Header("Behaviour")]
    [SerializeField] private MonoBehaviour rootBehaviour;

    [Header("References")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private MonoBehaviour pointable;

    [Header("Setting")]
    [SerializeField] private float evadeDistance;

    private IBehaviourNode _rootBehaviour;

    public NavMeshAgent Agent => agent;
    public IPointable Pointable { get; private set; }
    public float EvadeDistance => evadeDistance;

    private void Awake()
    {
        Pointable = pointable.GetComponent<IPointable>();
        _rootBehaviour = rootBehaviour.GetComponent<IBehaviourNode>();
    }

    private void Update()
    {
        _rootBehaviour.Execute();
    }
}