using System.Collections.Generic;
using UnityEngine;
public class EnemyStateAttack : EnemyState
{
    private PersecutionDetector _persecutionDetector;
    private AttackDetector _attackDetector;
    private EnemyDamageDealer _damageDealer;

    public EnemyStateAttack(EnemyStateMachine stateMachine, Flipper flipper, PersecutionDetector persecutionDetector, EnemyAnimator animator, AttackDetector attackDetector, EnemyDamageDealer damageDealer) : base(stateMachine, persecutionDetector, animator, attackDetector)
    {
        _persecutionDetector = persecutionDetector;
        _attackDetector = attackDetector;
        _damageDealer = damageDealer;
    }

    public override void Enter()
    {
        Animator.SetTrueAttackAnimation();

        Animator.CompletedStrike += DealDamageToPlayersInAttackZone;
        _attackDetector.AvailableTargetAdded += SetTrueAttackAnimation;
        _attackDetector.AvailableTargetRemoved += TrySetFalseAttackAnimation;
        Animator.AttackAnimationEnded += TryChangeState;
    }

    public override void Exit()
    {
        Animator.CompletedStrike -= DealDamageToPlayersInAttackZone;
        _attackDetector.AvailableTargetAdded -= SetTrueAttackAnimation;
        _attackDetector.AvailableTargetRemoved -= TrySetFalseAttackAnimation;
        Animator.AttackAnimationEnded -= TryChangeState;
    }

    private void DealDamageToPlayersInAttackZone()
    {
        List<IDamageable> targets = new List<IDamageable>();

        foreach (IDamageable target in _attackDetector.GetPlayersHealthInAttackZone())
        {
            targets.Add(target);
        }

        _damageDealer.DealDamageToTargets(targets);
    }

    private void TrySetFalseAttackAnimation()
    {
        if (_attackDetector.GetPlayersHealthInAttackZone().Count == 0)
        {
            Animator.SetFalseAttackAnimation();
        }
    }

    private void SetTrueAttackAnimation()
    {
        Animator.SetTrueAttackAnimation();
    }

    private void TryChangeState()
    {
        if (_attackDetector.GetPlayersHealthInAttackZone().Count == 0)
        {
            if (_persecutionDetector.GetPlayersInPersecutionZone().Count > 0)
            {
                StateMachine.ChangeState<EnemyStatePersecution>();
                return;
            }
            else
            {
                StateMachine.ChangeState<EnemyStatePatrolling>();
                return;
            }
        }
    }
}