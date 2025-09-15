using System.Collections.Generic;

public class EnemyStateAttack : EnemyState
{
    private EnemyDetector _persecutionDetector;
    private EnemyDetector _attackDetector;
    private EnemyDamageDealer _damageDealer;

    public EnemyStateAttack(EnemyStateMachine stateMachine, Flipper flipper, EnemyDetector persecutionDetector, EnemyAnimator animator, EnemyDetector attackDetector, EnemyDamageDealer damageDealer) : base(stateMachine, persecutionDetector, animator, attackDetector)
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

        foreach (IDamageable target in _attackDetector.Targets)
        {
            targets.Add(target);
        }

        _damageDealer.DealDamageToTargets(targets);
    }

    private void TrySetFalseAttackAnimation()
    {
        if (_attackDetector.Targets.Count == 0)
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
        if (_attackDetector.Targets.Count == 0)
        {
            if (_persecutionDetector.Targets.Count > 0)
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