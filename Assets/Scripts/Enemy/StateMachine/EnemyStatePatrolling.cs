using UnityEngine.UI;

public class EnemyStatePatrolling : EnemyStateMovement<MoverByPoints>
{
    public EnemyStatePatrolling(EnemyStateMachine stateMachine, EnemyAnimator animator, PlayerDetectionDetector persecutionDetector, MoverByPoints mover, Flipper flipper) : base(stateMachine, animator, persecutionDetector, mover, flipper)
    {
    }

    public override void Enter()
    {
        PersecutionDetector.PlayerEnteredAffectedArea += TryEnterStateOfPersecution;
    }

    public override void Update()
    {
        Flipper.TurnFrontTowardsTarget(Mover.TargetToMoveTowards);

        if (Mover.HasPointReached())
        {
            Mover.SetNextPointAsTarget();
        }
        else
        {
            base.Update();
        }
    }

    public override void Exit()
    {
        PersecutionDetector.PlayerLeftAffectedArea -= TryEnterStateOfPersecution;
    }

    private void TryEnterStateOfPersecution()
    {
        if (PersecutionDetector.Player != null && StateMachine.CurrentState.GetType() != typeof(EnemyStateAttack))
        {
            StateMachine.ChangeState<EnemyStatePersecution>();
        }
    }
}