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
    [SerializeField] private MonoBehaviour health;
    [SerializeField] private Transform head;
    [SerializeField] private MonoBehaviour firearm;

    [Header("Setting")]
    [SerializeField] private float evadeDistance;
    [SerializeField] private float lookingDistance;
    [SerializeField] private float lookingAngle;
    [SerializeField] private float lookingPersistence;
    [SerializeField] private float reloadDelay;

    private IBehaviourNode _rootBehaviour;
    private IHealth _health;

    public NavMeshAgent Agent => agent;
    public IPointable Pointable { get; private set; }
    public SoldierStrategy Strategy => strategy;
    public IHealth Health => _health;
    public Transform Head => head;
    public IFirearm Firearm { get; private set; }

    public float EvadeDistance => evadeDistance;
    public float LookingDistance => lookingDistance;
    public float LookingAngle => lookingAngle;
    public float LookingPersistence => lookingPersistence;
    public float ReloadDelay => reloadDelay;

    private void Awake()
    {
        Pointable = pointable.GetComponent<IPointable>();
        _rootBehaviour = rootBehaviour.GetComponent<IBehaviourNode>();
        _health = health.GetComponent<IHealth>();
        Firearm = firearm.GetComponent<IFirearm>();
    }

    private void Update()
    {
        _rootBehaviour.Execute();
    }
}