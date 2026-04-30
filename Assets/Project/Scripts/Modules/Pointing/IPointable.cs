using System;
using UnityEngine;

public interface IPointable
{
    public event Action<PointableEvent> OnEnter;
    public event Action<PointableEvent> OnStay;
    public event Action<PointableEvent> OnExit;

    public bool IsBeeingPointed { get; }

    public void Point(Vector3 origin, Vector3 target);
    public void Ignore(Vector3 origin, Vector3 target);
}