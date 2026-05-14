using UnityEngine;

public interface IFirearm
{
    public ICartridge Cartridge { get; set; }
    public int Reload(int amount);
    public bool Shoot();
}
