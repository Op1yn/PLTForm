using UnityEngine;

public class EnemyStatePatrolling : EnemyStateMovement
{
    float _speedCoefficient = 1f;

    public EnemyStatePatrolling(EnemyStateMachine stateMachine, Transform transform, Flipper flipper, EnemyDetector persecutionDetector, EnemyAnimator enemyAnimator, EnemyDetector attackDetector, EnemyMover enemyMover) : base(stateMachine, transform, flipper, persecutionDetector, enemyAnimator, attackDetector, enemyMover)
    {
    }

    public override void Enter()
    {
        PersecutionDetector.AvailableTargetAdded += TryEnterStateOfPersecution;
        EnemyMover.SetSpeedCoefficient(_speedCoefficient);
    }

    public override void Update()
    {
        if (EnemyMover.HasPointReached())
            EnemyMover.SwitchRoutePoint();

        base.Update();
    }

    public override void Exit()
    {
        PersecutionDetector.AvailableTargetRemoved -= TryEnterStateOfPersecution;
    }

    private void TryEnterStateOfPersecution()
    {
        if (PersecutionDetector.Targets.Count > 0)
        {
            StateMachine.ChangeState<EnemyStatePersecution>();
        }
    }
}