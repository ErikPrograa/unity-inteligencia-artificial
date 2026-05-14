using System.Collections;
using UnityEngine;


public class SoldierSafeAction : ActionComponentNode
{
    [SerializeField] private SoldierController soldier;
    [SerializeField] private bool waitToReachPosition;

    protected override BehaviourState Action()
    {
        if (!soldier.Strategy.GetNearestSafePoint(
            soldier.transform.position, out var target))
            return BehaviourState.Failure;
        soldier.Agent.SetDestination(target);

        if (waitToReachPosition)
        {
            float distance = Vector3.Distance(target, soldier.transform.position);
            if (distance > soldier.Agent.stoppingDistance + 1)
                return BehaviourState.Running;
        }

        
        return BehaviourState.Success;
    }
}