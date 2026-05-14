using System.Collections;
using UnityEngine;


public class AutomaticFirearm : MonoBehaviour, IFirearm
{
    [SerializeField] private MonoBehaviour cartridge;
    [SerializeField] private Transform bulletOrigin;
    [SerializeField] private float shootDelay;

    private float _elapsedTime;

    public ICartridge Cartridge 
    {
        get;
        set;
    }

    private void Awake()
    {
        Cartridge = cartridge.GetComponent<ICartridge>();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
    }

    public int Reload(int amount)
    {
        if (Cartridge == null)
            return amount;

        amount = Mathf.Abs(amount);
        int available = Cartridge.Capacity - Cartridge.Amount;
        int toAdd = Mathf.Clamp(amount, 0, available);
        Cartridge.Amount += toAdd;

        return amount - toAdd;
    }

    public bool Shoot()
    {
        if (_elapsedTime < shootDelay)
            return false;

        if (Cartridge == null || Cartridge.Amount == 0)
            return false;

        IBullet bullet = Cartridge.Dispatch();
        if (bullet == null)
            return false;

        _elapsedTime = 0;
        bullet.Throw(bulletOrigin.position, bulletOrigin.forward);
        return true;
    }
}