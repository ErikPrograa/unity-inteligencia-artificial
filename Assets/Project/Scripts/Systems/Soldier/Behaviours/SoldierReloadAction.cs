using System.Collections;
using UnityEngine;

public class SoldierReloadAction : ActionComponentNode
{
    [SerializeField] private SoldierController soldier;
    [SerializeField] private int reloadAmount;

    private float _elapsedTime;

    protected override BehaviourState Action()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime < soldier.ReloadDelay)
            return BehaviourState.Running;

        _elapsedTime = 0;
        soldier.Firearm.Reload(reloadAmount);
        return BehaviourState.Success;
    }
}