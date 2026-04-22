using UnityEngine;

public class DoorOpeningState : StateObject
{
    private readonly DoorController _controller;

    public float ElapsedTime { get; private set; }

    public DoorOpeningState(DoorController controller)
    {
        _controller = controller;
    }

    public override void OnEnter()
    {
        ElapsedTime = 0f;
        _controller.ClearOpenRequest();
    }

    public override void OnUpdate()
    {
        float duration = Mathf.Max(0.0001f, _controller.OpenCloseDuration);
        float t = Mathf.Clamp01(ElapsedTime / duration);
        float angle = Mathf.LerpAngle(_controller.ClosedAngleY, _controller.OpenAngleY, t);
        _controller.SetDoorAngleY(angle);
        ElapsedTime += Time.deltaTime;
    }

    public override void OnExit()
    {
        _controller.SetDoorAngleY(_controller.OpenAngleY);
    }
}
