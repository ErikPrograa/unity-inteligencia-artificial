using UnityEngine;

public class DoorOpenState : StateObject
{
    private readonly DoorController _controller;

    public float ElapsedTime { get; private set; }

    public DoorOpenState(DoorController controller)
    {
        _controller = controller;
    }

    public override void OnEnter()
    {
        ElapsedTime = 0f;
        _controller.SetDoorAngleY(_controller.OpenAngleY);
    }

    public override void OnUpdate()
    {
        ElapsedTime += Time.deltaTime;
    }

    public override void OnExit()
    {
    }
}
