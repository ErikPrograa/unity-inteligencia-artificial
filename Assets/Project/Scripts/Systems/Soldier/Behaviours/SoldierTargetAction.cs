using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SoldierTargetAction : ActionComponentNode
{
    [SerializeField] private SoldierController soldier;

    protected override BehaviourState Action()
    {
        Vector3 playerPosition = soldier.Strategy.GetRealPlayerPosition();
        if (!NavMesh.SamplePosition(playerPosition, out var hit, int.MaxValue, NavMesh.AllAreas))
            return BehaviourState.Failure;

        float distance = Vector3.Distance(soldier.transform.position, hit.position);
        if (distance <= soldier.Agent.stoppingDistance)
            return BehaviourState.Success;

        soldier.Agent.SetDestination(hit.position);
        return BehaviourState.Running;
    }
}