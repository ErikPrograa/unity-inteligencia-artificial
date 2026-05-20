using UnityEngine;

public class PointableEvent
{
    public IPointable Pointable { get; private set; }
    public Vector3 Origin { get; private set; }
    public Vector3 Target { get; private set; }

    public PointableEvent(IPointable pointable, Vector3 origin, Vector3 target)
    {
        Pointable = pointable;
        Origin = origin;
        Target = target;
    }
}