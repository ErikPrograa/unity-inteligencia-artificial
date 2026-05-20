using System.Collections;
using UnityEngine;

public class TrafficLightYellowState : IState
{
    private TrafficLightController _controller;

    public float ElapsedTime { get; private set; }

    public TrafficLightYellowState(TrafficLightController controller)
    {
        _controller = controller;
    }

    public void OnEnter()
    {
        ElapsedTime = 0;
        _controller.YellowLightRenderer.material.color = Color.yellow;
    }

    public void OnUpdate(float deltaTime)
    {
        ElapsedTime += deltaTime;
    }

    public void OnExit()
    {
        _controller.YellowLightRenderer.material.color = Color.black;
    }
}