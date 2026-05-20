using UnityEngine;

public class DoorOpenState : IState
{
    private readonly DoorController _controller;

    public float ElapsedTime { get; private set; }

    public DoorOpenState(DoorController controller)
    {
        _controller = controller;
    }

    public void OnEnter()
    {
        ElapsedTime = 0f;
        _controller.SetDoorAngleY(_controller.OpenAngleY);
    }

    public void OnUpdate(float deltaTime)
    {
        ElapsedTime += deltaTime;
    }

    public void OnExit()
    {
    }
}
