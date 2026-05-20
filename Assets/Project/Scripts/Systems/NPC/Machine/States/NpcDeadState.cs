
using System;
using UnityEngine;

public class NpcDeadState : SubStateMachine
{
    private NpcController _controller;
    private NpcCrawlState _crawl;

    public NpcDeadState(IGraph<IState, StateTransition> graph, NpcController controller) : base(graph)
    {
        _controller = controller;

        _crawl = new NpcCrawlState(controller);
        NpcAttackState attack = new NpcAttackState(controller);

        graph.AddVertex(_crawl);
        graph.AddVertex(attack);

        StateTransition crawlToAttack = new StateTransition(attack, CrawlToAttack);
        graph.AddEdge(_crawl, crawlToAttack);

        StateTransition attackToCrawl = new StateTransition(_crawl, AttackToCrawl);
        graph.AddEdge(attack, attackToCrawl);
    }

    public override void OnEnter()
    {
        _controller.Animator.SetTrigger("dead");
        SetState(_crawl);
    }

    private bool AttackToCrawl()
    {
        float distance = Vector3.Distance(_controller.Player.transform.position,
            _controller.transform.position);

        return distance > _controller.DetectionDistance;
    }

    private bool CrawlToAttack()
    {
        return !AttackToCrawl();
    }
}