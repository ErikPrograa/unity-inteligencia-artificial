using System.Collections;
using UnityEngine;

public class BulletComponentFactory : BulletFactory
{
    [SerializeField] private GameObject bulletPrefab;

    public override IBullet Create()
    {
        GameObject instance = Instantiate(bulletPrefab);
        IBullet bullet = instance.GetComponent<IBullet>();
        if (bullet == null)
        {
            Destroy(instance);
            return null;
        }

        return bullet;
    }
}