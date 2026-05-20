using UnityEngine;

public class SoldierPointedDecision : DecisionComponentNode
{
    [SerializeField] private SoldierController soldier;

    protected override bool Decision()
    {
        return soldier.Pointable.IsBeeingPointed;
    }
}