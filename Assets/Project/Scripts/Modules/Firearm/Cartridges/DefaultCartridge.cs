using System.Collections;
using UnityEngine;

public class DefaultCartridge : MonoBehaviour, ICartridge
{
    [SerializeField] private BulletFactory bulletFactory;
    [SerializeField] private int capacity;
    [SerializeField] private int amount;

    public int Capacity 
    {
        get => capacity;
        set => capacity = value;
    }
    public int Amount 
    {
        get => amount;
        set => amount = value;
    }

    public IBullet Dispatch()
    {
        if (Amount <= 0)
            return null;

        IBullet bullet = bulletFactory.Create();
        if (bullet == null)
            return null;

        Amount--;
        return bullet;
    }
}