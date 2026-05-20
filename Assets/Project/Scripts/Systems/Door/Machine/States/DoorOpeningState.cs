using UnityEngine;

public class DoorOpeningState : IState
{
    private readonly DoorController _controller;

    public float ElapsedTime { get; private set; }

    public DoorOpeningState(DoorController controller)
    {
        _controller = controller;
    }

    public void OnEnter()
    {
        ElapsedTime = 0f;
        _controller.ClearOpenRequest();
    }

    public void OnUpdate(float deltaTime)
    {
        float duration = Mathf.Max(0.0001f, _controller.OpeningDuration);
        float t = Mathf.Clamp01(ElapsedTime / duration);
        float angle = Mathf.LerpAngle(_controller.ClosedAngleY, _controller.OpenAngleY, t);
        _controller.SetDoorAngleY(angle);
        ElapsedTime += deltaTime;
    }

    public void OnExit()
    {
        _controller.SetDoorAngleY(_controller.OpenAngleY);
    }
}
