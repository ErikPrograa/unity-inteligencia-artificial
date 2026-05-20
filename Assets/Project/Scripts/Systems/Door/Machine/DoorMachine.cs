using UnityEngine;

public class DoorMachine : BaseStateMachine
{
    private readonly DoorController _controller;
    private readonly DoorOpenState _open;
    private readonly DoorClosingState _closing;
    private readonly DoorClosedState _close;
    private readonly DoorOpeningState _opening;

    public DoorMachine(IGraph<IState, StateTransition> graph, DoorController controller) : base(graph)
    {
        _controller = controller;

        _open = new DoorOpenState(controller);
        _closing = new DoorClosingState(controller);
        _close = new DoorClosedState(controller);
        _opening = new DoorOpeningState(controller);

        graph.AddVertex(_open);
        graph.AddVertex(_closing);
        graph.AddVertex(_close);
        graph.AddVertex(_opening);

        StateTransition closeToOpening = new(_opening, CloseToOpening);
        graph.AddEdge(_close, closeToOpening);

        StateTransition openingToOpen = new(_open, OpeningToOpen);
        graph.AddEdge(_opening, openingToOpen);

        StateTransition openToClosing = new(_closing, OpenToClosing);
        graph.AddEdge(_open, openToClosing);

        StateTransition closingToClose = new(_close, ClosingToClose);
        graph.AddEdge(_closing, closingToClose);

        SetState(_close);
    }

    private bool CloseToOpening()
    {
        return _controller.OpenRequestPending
            || _close.ElapsedTime >= _controller.TimeClosedBeforeOpen;
    }

    private bool OpeningToOpen()
    {
        return _opening.ElapsedTime >= _controller.OpeningDuration;
    }

    private bool OpenToClosing()
    {
        return _controller.CloseRequestPending
            || _open.ElapsedTime >= _controller.TimeOpenBeforeClose;
    }

    private bool ClosingToClose()
    {
        return _closing.ElapsedTime >= _controller.ClosingDuration;
    }
}
