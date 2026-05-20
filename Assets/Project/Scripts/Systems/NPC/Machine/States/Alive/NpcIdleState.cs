
using UnityEngine;

public class NpcIdleState : NpcState
{
    private float _elapsedTime;
    private float _timeToChange;

    public NpcIdleState(NpcController controller) : base(controller)
    {
        
    }

    public override void OnEnter()
    {
        Debug.Log("Idle Enter");
    }

    public override void OnUpdate(float deltaTime)
    {
        _elapsedTime += deltaTime;
        if(_elapsedTime < _timeToChange)
            return;

        int index = Random.Range(1, 4);
        _controller.Animator.SetFloat("idle_index", index);

        _timeToChange = Random.Range(
            _controller.MinIdleChangeTime, _controller.MaxIdleChangeTime);
        _elapsedTime = 0;
    }

    public override void OnExit()
    {
        Debug.Log("Idle Exit");
    }
}