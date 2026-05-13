using UnityEngine;
using UnityEngine.AI;

public class SoldierController : MonoBehaviour
{
    [Header("Behaviour")]
    [SerializeField] private MonoBehaviour rootBehaviour;

    [Header("References")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private MonoBehaviour pointable;
    [SerializeField] private SoldierStrategy strategy;
    [SerializeField] private Transform head;

    [Header("Setting")]
    [SerializeField] private float evadeDistance;
    [SerializeField] private float lookingDistance;
    [SerializeField] private float lookingAngle;
    [SerializeField] private float lookingPersistence;

    private IBehaviourNode _rootBehaviour;

    public NavMeshAgent Agent => agent;
    public IPointable Pointable { get; private set; }
    public SoldierStrategy Strategy => strategy;
    public Transform Head => head;

    public float EvadeDistance => evadeDistance;
    public float LookingDistance => lookingDistance;
    public float LookingAngle => lookingAngle;
    public float LookingPersistence => lookingPersistence;

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