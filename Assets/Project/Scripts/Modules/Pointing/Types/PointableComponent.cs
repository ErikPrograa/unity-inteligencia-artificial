using System;
using UnityEngine;

public class PointableComponent : MonoBehaviour, IPointable
{
    public event Action<PointableEvent> OnEnter;
    public event Action<PointableEvent> OnStay;
    public event Action<PointableEvent> OnExit;

    public bool IsBeeingPointed { get; private set; }


    public void Point(Vector3 origin, Vector3 target)
    {
        if(!IsBeeingPointed)
        {
            IsBeeingPointed = true;
            OnEnter?.Invoke(new(this, origin, target));
            return;
        }

        OnStay?.Invoke(new(this, origin, target));
    }

    public void Ignore(Vector3 origin, Vector3 target)
    {
        if (!IsBeeingPointed)
            return;

        IsBeeingPointed = false;
        OnExit?.Invoke(new(this, origin, target));
    }
}