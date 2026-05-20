using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;

public class NpcCrawlState : NpcState
{
    private Vector3 _target;

    public NpcCrawlState(NpcController controller) : base(controller)
    {

    }

    public override void OnEnter()
    {
        Debug.Log("Crawl");
        _target = GenerateTarget();
        _controller._isMoving = true;
    }

    public override void OnUpdate(float deltaTime)
    {
        Vector3 delta = _target - _controller.transform.position;
        if (delta.magnitude <= 0.1f)
            _target = GenerateTarget();

        Vector3 velocity = _controller.Agent.velocity;
        _controller.Animator.SetFloat("motion_x", velocity.x);
        _controller.Animator.SetFloat("motion_y", velocity.z);
        _controller.Animator.speed = velocity.magnitude;
    }

    public override void OnExit()
    {
        _controller._isMoving = false;
    }

    private Vector3 GenerateTarget()
    {
        Vector3 direction = Random.onUnitSphere * _controller.MaxPatrolDistance;
        Vector3 sourcePosition = _controller.transform.position + direction;
        if (!NavMesh.SamplePosition(sourcePosition, out NavMeshHit hit,
            _controller.MaxPatrolDistance, NavMesh.AllAreas))
            return Vector3.zero;


        _controller.Animator.SetBool("moving", true);
        _controller.Agent.SetDestination(hit.position);
        Debug.Log(hit.position);
        _controller._isMoving = true;
        return hit.position;
    }
}