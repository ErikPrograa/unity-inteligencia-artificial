using System.Collections;
using UnityEngine;


public class SoldierSafeAction : ActionComponentNode
{
    [SerializeField] private SoldierController soldier;

    protected override BehaviourState Action()
    {
        if (!soldier.Strategy.GetNearestSafePoint(
            soldier.transform.position, out var target))
            return BehaviourState.Failure;

        soldier.Agent.SetDestination(target);
        return BehaviourState.Success;
    }
}