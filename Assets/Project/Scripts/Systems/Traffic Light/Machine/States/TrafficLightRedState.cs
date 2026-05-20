using System.Collections;
using UnityEngine;

public class TrafficLightRedState : IState
{
    private TrafficLightController _controller;

    public float ElapsedTime { get; private set; }

    public TrafficLightRedState(TrafficLightController controller)
    {
        _controller = controller;
    }

    public void OnEnter()
    {
        ElapsedTime = 0;
        _controller.RedLightRenderer.material.color = Color.red;
    }

    public void OnUpdate(float deltaTime)
    {
        ElapsedTime += deltaTime;
    }

    public void OnExit()
    {
        _controller.RedLightRenderer.material.color = Color.black;
    }
}