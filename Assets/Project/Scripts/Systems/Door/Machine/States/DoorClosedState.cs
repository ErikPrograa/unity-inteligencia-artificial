using UnityEngine;

public class DoorClosedState : IState
{
    private readonly DoorController _controller;

    public float ElapsedTime { get; private set; }

    public DoorClosedState(DoorController controller)
    {
        _controller = controller;
    }

    public void OnEnter()
    {
        ElapsedTime = 0f;
        _controller.SetDoorAngleY(_controller.ClosedAngleY);
    }

    public void OnUpdate(float deltaTime)
    {
        ElapsedTime += deltaTime;
    }

    public void OnExit()
    {
    }
}
