using System.Collections;
using UnityEngine;

public class SoldierStrategy : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float playerOuterRadius;
    [SerializeField] private float playerInnerRadius;

    [SerializeField] private Transform playerLookOrigin;
    [SerializeField] private float safePointSearchRadius;
    [SerializeField] private LayerMask safePointLayers;

    private void Update()
    {
        Vector3 position = GetApproximatePlayerPosition();
        Debug.DrawLine(position, position + Vector3.up * 5, Color.red, 5);
    }

    public Vector3 GetApproximatePlayerPosition()
    {
        Vector3 direction = Random.onUnitSphere;
        direction.y = 0;
        direction.Normalize();

        float radiusDelta = playerOuterRadius - playerInnerRadius;
        float radius = Random.Range(0, radiusDelta);

        return playerTransform.position +
            direction * (playerInnerRadius + radius);
    }

    public Vector3 GetRealPlayerPosition()
    {
        return playerTransform.position;
    }

    public bool GetNearestSafePoint(Vector3 origin, out Vector3 target)
    {
        Collider[] result = Physics.OverlapSphere(
            origin, safePointSearchRadius, safePointLayers);
        if(result == null || result.Length == 0)
        {
            target = Vector3.zero;
            return false;
        }

        Vector3 closestPoint = Vector3.zero;
        float closestDistance = int.MaxValue;

        foreach(var collider in result)
        {
            float distance = Vector3.Distance(collider.transform.position, origin);
            if(distance < closestDistance)
            {
                Vector3 playerToPoint = collider.transform.position 
                    - playerLookOrigin.position;
                Ray ray = new(playerLookOrigin.position, playerToPoint.normalized);
                if(Physics.Raycast(ray, out var hit, float.MaxValue))
                {
                    if (((1 << hit.collider.gameObject.layer) & safePointLayers) != 0)
                        continue;
                }

                closestDistance = distance;
                closestPoint = collider.transform.position;
            }
        }

        target = closestPoint;
        return true;
    }
}