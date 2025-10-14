using UnityEngine;
public class EnemyStatePersecution : EnemyStateMovement<Follower>
{
    private PlayerDetectionDetector _attackDetector;

    public EnemyStatePersecution(EnemyStateMachine stateMachine, EnemyAnimator animator, PlayerDetectionDetector persecutionDetector, Follower mover, Flipper flipper, PlayerDetectionDetector attackDetector) : base(stateMachine, animator, persecutionDetector, mover, flipper)
    {
        _attackDetector = attackDetector;
    }

    public override void Enter()
    {
        Mover.SetTargetToMoveTowards(PersecutionDetector.Player.transform);
        _attackDetector.PlayerEnteredAffectedArea += TryEnterStateOfAttack;
    }

    public override void Update()
    {
        Flipper.TurnFrontTowardsTarget(Mover.TargetToMoveTowards);

        if (PersecutionDetector.Player == null)
        {
            StateMachine.ChangeState<EnemyStatePatrolling>();
        }

        base.Update();
    }

    public override void Exit()
    {
        _attackDetector.PlayerEnteredAffectedArea -= TryEnterStateOfAttack;
    }

    private void TryEnterStateOfAttack()
    {
        if (_attackDetector.Player != null)
        {
            StateMachine.ChangeState<EnemyStateAttack>();
        }
    }
}