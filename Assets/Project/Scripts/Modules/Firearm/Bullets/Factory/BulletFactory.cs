using UnityEngine;

public abstract class BulletFactory : MonoBehaviour
{
    public abstract IBullet Create();
}