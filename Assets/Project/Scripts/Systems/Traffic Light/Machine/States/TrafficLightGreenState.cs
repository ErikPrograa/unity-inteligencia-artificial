using System.Collections;
using UnityEngine;

public class TrafficLightGreenState : IState
{
    private TrafficLightController _controller;

    public float ElapsedTime { get; private set; }

    public TrafficLightGreenState(TrafficLightController controller)
    {
        _controller = controller;
    }

    public void OnEnter()
    {
        ElapsedTime = 0;
        _controller.GreenLightRenderer.material.color = Color.green;
    }

    public void OnUpdate(float deltaTime)
    {
        ElapsedTime += deltaTime;
    }

    public void OnExit()
    {
        _controller.GreenLightRenderer.material.color = Color.black;
    }
}