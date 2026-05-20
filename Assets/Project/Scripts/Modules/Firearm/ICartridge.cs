using System.Collections;
using UnityEngine;

public interface ICartridge
{
    public int Capacity { get; set; }
    public int Amount { get; set; }
    public IBullet Dispatch();
}