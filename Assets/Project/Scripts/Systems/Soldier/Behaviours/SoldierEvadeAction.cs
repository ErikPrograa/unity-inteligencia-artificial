using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SoldierEvadeAction : ActionComponentNode
{
    [SerializeField] private SoldierController soldier;

    private Vector3 _destination;

    private void Start()
    {
        soldier.Pointable.OnStay += OnPointableStay;
    }

    protected override BehaviourState Action()
    {
        soldier.SetAnimatorWalking(true);
        soldier.SetAnimatorDirection();
        soldier.SetAnimatorSpeed();

        if (!soldier.Pointable.IsBeeingPointed)
            return BehaviourState.Failure;

        float distance = Vector3.Distance(soldier.transform.position, _destination);
        return distance < 0.05f ?  BehaviourState.Success : BehaviourState.Running;
    }

    private void OnPointableStay(PointableEvent evt)
    {
        Vector3 position = soldier.transform.position;
        Vector3 xzPosition = new(position.x, 0, position.z);
        Vector3 xzTarget = new(evt.Target.x, 0, evt.Target.z);
        Vector3 xzDirection = (xzPosition - xzTarget).normalized;

        Vector3 destination = position + xzDirection * soldier.EvadeDistance;
        if (!NavMesh.SamplePosition(destination, out var hit, soldier.EvadeDistance, NavMesh.AllAreas))
            return;

        _destination = hit.position;
        soldier.Agent.SetDestination(_destination);
    }
}