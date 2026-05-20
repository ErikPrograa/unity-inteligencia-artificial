using System.Collections;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    [SerializeField] private MeshRenderer redLightRenderer;
    [SerializeField] private MeshRenderer yellowLightRenderer;
    [SerializeField] private MeshRenderer greenLightRenderer;

    [SerializeField] private float redLightDuration;
    [SerializeField] private float yellowLightDuration;
    [SerializeField] private float greenLightDuration;

    public MeshRenderer RedLightRenderer => redLightRenderer;
    public MeshRenderer YellowLightRenderer => yellowLightRenderer;
    public MeshRenderer GreenLightRenderer => greenLightRenderer;

    public float RedLightDuration => redLightDuration;
    public float YellowLightDuration => yellowLightDuration;
    public float GreenLightDuration => greenLightDuration;

    private TrafficLightMachine _machine;

    private void Awake()
    {
        var graph = new UnorderedGraph<IState, StateTransition>();
        _machine = new TrafficLightMachine(graph, this);
    }

    private void Update()
    {
        _machine.Update(Time.deltaTime);
    }
}