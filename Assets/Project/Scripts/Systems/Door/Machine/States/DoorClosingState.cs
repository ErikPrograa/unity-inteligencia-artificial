using UnityEngine;

public class DoorClosingState : IState
{
    private readonly DoorController _controller;

    public float ElapsedTime { get; private set; }

    public DoorClosingState(DoorController controller)
    {
        _controller = controller;
    }

    public void OnEnter()
    {
        ElapsedTime = 0f;
        _controller.ClearCloseRequest();
    }

    public void OnUpdate(float deltaTime)
    {
        float duration = Mathf.Max(0.0001f, _controller.ClosingDuration);
        float t = Mathf.Clamp01(ElapsedTime / duration);
        float angle = Mathf.LerpAngle(_controller.OpenAngleY, _controller.ClosedAngleY, t);
        _controller.SetDoorAngleY(angle);
        ElapsedTime += deltaTime;
    }

    public void OnExit()
    {
        _controller.SetDoorAngleY(_controller.ClosedAngleY);
    }
}
