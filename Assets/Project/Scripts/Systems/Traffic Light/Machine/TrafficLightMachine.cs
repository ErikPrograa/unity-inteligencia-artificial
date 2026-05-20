using System.Collections;
using UnityEngine;

public class TrafficLightMachine : BaseStateMachine
{
    TrafficLightController _controller;
    TrafficLightRedState _red;
    TrafficLightYellowState _yellow;
    TrafficLightGreenState _green;

    public TrafficLightMachine(IGraph<IState, StateTransition> graph,
        TrafficLightController controller) : base(graph)
    {
        _controller = controller;

        _red = new(controller);
        _yellow = new(controller);
        _green = new(controller);

        graph.AddVertex(_red);
        graph.AddVertex(_yellow);
        graph.AddVertex(_green);

        StateTransition redToGreen = new(_green, RedToGreen);
        graph.AddEdge(_red, redToGreen);

        StateTransition greenToYellow = new(_yellow, GreenToYellow);
        graph.AddEdge(_green, greenToYellow);

        StateTransition yellowToRed = new(_red, YellowToRed);
        graph.AddEdge(_yellow, yellowToRed);

        SetState(_green);
    }

    private bool RedToGreen()
    {
        return _red.ElapsedTime >= _controller.RedLightDuration;
    }

    private bool GreenToYellow()
    {
        return _green.ElapsedTime >= _controller.GreenLightDuration;
    }

    private bool YellowToRed()
    {
        return _yellow.ElapsedTime >= _controller.YellowLightDuration;
    }
}