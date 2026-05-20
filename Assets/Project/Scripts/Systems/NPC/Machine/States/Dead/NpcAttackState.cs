using System.Collections;
using UnityEngine;

public class NpcAttackState : NpcState
{
    public NpcAttackState(NpcController controller) : base(controller)
    {

    }

    public override void OnEnter()
    {
        _controller.Animator.SetBool("attack", true);
    }

    public override void OnUpdate(float deltaTime)
    {
        Debug.Log("Attack");
    }

    public override void OnExit()
    {
        _controller.Animator.SetBool("attack", false);
    }
}