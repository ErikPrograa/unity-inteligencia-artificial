using System.Collections;
using UnityEngine;

public class SoldierLookingDecision : DecisionComponentNode
{
    [SerializeField] private SoldierController soldier;

    private float _persistenceTime;
    private bool _hasSeenPlayer;

    private void Update()
    {
        _persistenceTime += Time.deltaTime;
    }

    protected override bool Decision()
    {
        Vector3 playerPosition = soldier.Strategy.GetRealPlayerPosition();
        Vector3 direction = (playerPosition - soldier.Head.position).normalized;

        float angle = Vector3.Angle(direction, soldier.Head.forward);
        if (angle > soldier.LookingAngle)
            return CheckPersistence();

        Ray ray = new Ray(soldier.Head.position, direction);
        if (!Physics.Raycast(ray, out var hit, soldier.LookingDistance))
            return CheckPersistence();

        if (hit.rigidbody == null)
            return CheckPersistence();

        _persistenceTime = 0;
        _hasSeenPlayer = hit.rigidbody.CompareTag("Player");
        return _hasSeenPlayer;
    }

    private bool CheckPersistence()
    {
        if (_hasSeenPlayer && _persistenceTime <= soldier.LookingPersistence)
            return true;

        _hasSeenPlayer = false;
        _persistenceTime = 0;
        return false;
    }
}