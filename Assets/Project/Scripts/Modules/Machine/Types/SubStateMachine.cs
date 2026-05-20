using System.Collections;
using UnityEngine;

public class SubStateMachine : BaseStateMachine, IState
{
    public SubStateMachine(IGraph<IState, StateTransition> graph) : base(graph)
    {

    }

    public virtual void OnEnter()
    {

    }

    public virtual void OnUpdate(float deltaTime)
    {
        Update(deltaTime);
    }

    public virtual void OnExit()
    {

    }
}