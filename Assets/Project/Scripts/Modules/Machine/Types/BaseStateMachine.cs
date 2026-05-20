
public abstract class BaseStateMachine : IMachine
{
    private IGraph<IState, StateTransition> _graph;
    private IState _current;

    public BaseStateMachine(IGraph<IState, StateTransition> graph)
    {
        _graph = graph;
    }

    public void SetState(IState state)
    {
        _current?.OnExit();
        _current = state;
        _current?.OnEnter();
    }

    public void Update(float deltaTime)
    {
        StateTransition[] transitions = _graph.GetNeighbors(_current);
        if(transitions != null || transitions.Length > 0)
        {
            foreach(var transition in transitions)
            {
                if(!transition.Trigger())
                    continue;

                _current?.OnExit();
                _current = transition.Target;
                _current?.OnEnter();
            }
        }

        _current?.OnUpdate(deltaTime);
    }
}