using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SoldierSeekAction : ActionComponentNode
{
    [SerializeField] private SoldierController soldier;

    private bool _initialized;
    private Vector3 _target;

    protected override BehaviourState Action()
    {
        if (!_initialized)
        {
            Vector3 playerPosition = soldier.Strategy.GetApproximatePlayerPosition();
            if (!NavMesh.SamplePosition(playerPosition, out var hit, int.MaxValue, NavMesh.AllAreas))
                return BehaviourState.Failure;

            _target = hit.position;
            _initialized = true;
        }

        float distance = Vector3.Distance(soldier.transform.position, _target);
        if(distance <= soldier.Agent.stoppingDistance)
        {
            _initialized = false;
            return BehaviourState.Success;
        }

        soldier.Agent.SetDestination(_target);
        return BehaviourState.Running;
    }
}