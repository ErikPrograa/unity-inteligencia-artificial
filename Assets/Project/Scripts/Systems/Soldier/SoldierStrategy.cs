using System.Collections;
using UnityEngine;

public class SoldierStrategy : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float playerOuterRadius;
    [SerializeField] private float playerInnerRadius;

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
}