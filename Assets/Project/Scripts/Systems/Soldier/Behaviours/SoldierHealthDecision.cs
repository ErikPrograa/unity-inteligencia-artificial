using System.Collections;
using UnityEngine;


public class SoldierHealthDecision : DecisionComponentNode
{
    [SerializeField] private SoldierController soldier;
    [SerializeField] private float lowHealthValue;

    protected override bool Decision()
    {
        return soldier.Health.Value <= lowHealthValue;
    }
}