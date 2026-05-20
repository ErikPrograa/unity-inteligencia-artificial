
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private MonoBehaviour health;

    [Header("Idle")]
    [SerializeField] private float minIdleChangeTime;
    [SerializeField] private float maxIdleChangeTime;

    [Header("Patrol")]
    [SerializeField] private float probabilityToPatrol;
    [SerializeField] private float maxPatrolDistance;

    [Header("Crawl")]
    [SerializeField] private float detectionDistance;

    public bool _isMoving;

    public Animator Animator => animator;
    public NavMeshAgent Agent => agent;
    public IHealth Health { get; private set;}
    public GameObject Player { get; private set; }
    
    public float ProbailityToPatrol => probabilityToPatrol;
    public float MinIdleChangeTime => minIdleChangeTime;
    public float MaxIdleChangeTime => maxIdleChangeTime;
    public float MaxPatrolDistance => maxPatrolDistance;
    public float DetectionDistance => detectionDistance;

    private BaseStateMachine _machine;

    private void Awake()
    {
        Health = health.GetComponent<IHealth>();
        Player = GameObject.FindGameObjectWithTag("Player");

        var _graph = new OrderedGraph<IState, StateTransition>();
        _machine = new NpcMachine(_graph, this);
    }

    private void Update()
    {
        _machine.Update(Time.deltaTime);
    }
}