using UnityEngine;


public class SoldierAmmoDecision : DecisionComponentNode
{
    [SerializeField] private SoldierController soldier;
    [SerializeField] private int lowAmmoAmount;

    protected override bool Decision()
    {
        return soldier.Firearm.Cartridge.Amount < lowAmmoAmount;
    }
}