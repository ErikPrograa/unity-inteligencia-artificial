using UnityEngine;

public class DoorClosedState : StateObject
{
    private readonly DoorController _controller;

    public float ElapsedTime { get; private set; }

    public DoorClosedState(DoorController controller)
    {
        _controller = controller;
    }

    public override void OnEnter()
    {
        ElapsedTime = 0f;
        _controller.SetDoorAngleY(_controller.ClosedAngleY);
    }

    public override void OnUpdate()
    {
        ElapsedTime += Time.deltaTime;
    }

    public override void OnExit()
    {
    }
}
