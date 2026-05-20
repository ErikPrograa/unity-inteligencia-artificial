using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.XR;


public class NpcAliveState : SubStateMachine
{
    private NpcController _controller;
    private NpcIdleState _idle;

    public NpcAliveState(IGraph<IState, StateTransition> graph, NpcController controller) : base(graph)
    {
        _controller = controller;

        _idle = new NpcIdleState(controller);
        NpcPatrolState patrol = new NpcPatrolState(controller);

        graph.AddVertex(_idle);
        graph.AddVertex(patrol);

        StateTransition idleToPatrol = new(patrol, IdleToPatrol);
        graph.AddEdge(_idle, idleToPatrol);

        StateTransition patrolToIdle = new(_idle, PatrolToIdle);
        graph.AddEdge(patrol, patrolToIdle);
    }

    public override void OnEnter()
    {
        base.OnEnter();
        SetState(_idle);
    }

    private bool IdleToPatrol()
    {
        float alpha = Random.Range(0.0f, 1.0f);
        return alpha < _controller.ProbailityToPatrol;
    }

    private bool PatrolToIdle()
    {
        return !_controller._isMoving;
    }
}