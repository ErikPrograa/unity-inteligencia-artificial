
using Unity.VisualScripting;

public class NpcMachine : BaseStateMachine
{
    private NpcController _controller;

    public NpcMachine(IGraph<IState, StateTransition> graph, NpcController controller) : base(graph)
    {
        _controller = controller;

        NpcAliveState alive = new NpcAliveState(graph, controller);
        NpcDeadState dead = new NpcDeadState(graph, controller);

        graph.AddVertex(alive);
        graph.AddVertex(dead);

        StateTransition aliveToDead = new(dead, AliveToDead);
        graph.AddEdge(alive, aliveToDead);

        SetState(alive);
    }

    

    private bool AliveToDead()
    {
        bool test = _controller.Health.Value == 0;
        return test;
    }
}