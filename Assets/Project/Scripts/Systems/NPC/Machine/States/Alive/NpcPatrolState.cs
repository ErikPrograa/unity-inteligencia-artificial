
using UnityEngine;
using UnityEngine.AI;

public class NpcPatrolState : NpcState
{
    private Vector3 _target;

    public NpcPatrolState(NpcController controller) : base(controller)
    {
        
    }

    public override void OnEnter()
    {
        Debug.Log("Patrol");
        Vector3 direction = Random.onUnitSphere * _controller.MaxPatrolDistance;
        Vector3 sourcePosition = _controller.transform.position + direction;
        if(!NavMesh.SamplePosition(sourcePosition, out NavMeshHit hit, 
            _controller.MaxPatrolDistance, NavMesh.AllAreas))
        {
            _controller._isMoving = false;
            return;
        }

        _controller.Animator.SetBool("moving", true);

        _controller._isMoving = true;
        _controller.Agent.SetDestination(hit.position);
        _target = hit.position;
    }

    public override void OnUpdate(float deltaTime)
    {
        Vector3 delta = _target - _controller.transform.position;
        if(delta.magnitude <= 0.1f)
            _controller._isMoving = false;

        Vector3 velocity = _controller.Agent.velocity;
        _controller.Animator.SetFloat("motion_x", velocity.x);
        _controller.Animator.SetFloat("motion_y", velocity.z);
        _controller.Animator.speed = velocity.magnitude;
    }

    public override void OnExit()
    {
        _controller.Animator.SetBool("moving", false);
        _controller.Animator.speed = 1;
    }
}