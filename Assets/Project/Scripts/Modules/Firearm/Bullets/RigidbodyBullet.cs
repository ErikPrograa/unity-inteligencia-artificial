using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyBullet : MonoBehaviour, IBullet
{
    [SerializeField] private float force;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Throw(Vector3 origin, Vector3 direction)
    {
        _rigidbody.position = origin;
        direction.Normalize();
        _rigidbody.AddForce(direction * force, ForceMode.Impulse);
    }
}