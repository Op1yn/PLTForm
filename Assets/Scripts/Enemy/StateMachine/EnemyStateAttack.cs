public class EnemyStateAttack : EnemyState
{
    private PlayerDetectionDetector _persecutionDetector;
    private PlayerDetectionDetector _attackDetector;
    private EnemyDamageDealer _damageDealer;

    public EnemyStateAttack(EnemyStateMachine stateMachine, EnemyAnimator animator, PlayerDetectionDetector persecutionDetector, PlayerDetectionDetector attackDetector, EnemyDamageDealer damageDealer) : base(stateMachine, animator, persecutionDetector)
    {
        _persecutionDetector = persecutionDetector;
        _attackDetector = attackDetector;
        _damageDealer = damageDealer;
    }

    public override void Enter()
    {
        Animator.SetTrueAttackAnimation();

        Animator.CompletedStrike += _damageDealer.TryDamagePlayer;
        _attackDetector.PlayerEnteredAffectedArea += Animator.SetTrueAttackAnimation;
        _attackDetector.PlayerLeftAffectedArea += Animator.SetFalseAttackAnimation;
        Animator.AttackAnimationEnded += TryChangeState;
    }

    public override void Exit()
    {
        Animator.CompletedStrike -= _damageDealer.TryDamagePlayer;
        _attackDetector.PlayerEnteredAffectedArea -= Animator.SetTrueAttackAnimation;
        _attackDetector.PlayerLeftAffectedArea -= Animator.SetFalseAttackAnimation;
        Animator.AttackAnimationEnded -= TryChangeState;
    }

    private void TryChangeState()
    {
        if (_attackDetector.Player == null)
        {
            if (_persecutionDetector.Player == null)
            {
                StateMachine.ChangeState<EnemyStatePatrolling>();
                return;
            }
            else
            {
                StateMachine.ChangeState<EnemyStatePersecution>();
                return;
            }
        }
    }
}