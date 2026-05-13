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

        soldier.Agent.SetDestination(hit.position);
        return BehaviourState.Success;
    }
}