using System.Collections;
using UnityEngine;


public class SoldierShootAction : ActionComponentNode
{
    [SerializeField] private SoldierController soldier;

    protected override BehaviourState Action()
    {
        soldier.Firearm.Shoot();
        return BehaviourState.Success;
    }
}