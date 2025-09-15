using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyStatePersecution : EnemyStateMovement
{
    //private float _distanceCeasePersecution = 1.2f;
    //private IReadOnlyList<Health> _playersInZoneVisible;
    private EnemyDetector _attackDetector;
    private float _speedCoefficientPersecution;
    private Follower _follower;

    public EnemyStatePersecution(EnemyStateMachine stateMachine, Transform transform, Flipper flipper, EnemyDetector persecutionDetector, EnemyAnimator enemyAnimator, EnemyDetector attackDetector, EnemyMover enemyMover, float speedCoefficientPersecution, Follower follower) : base(stateMachine, transform, flipper, persecutionDetector, enemyAnimator, attackDetector, enemyMover)
    {
        _follower = follower;
        //_playersInZoneVisible = new List<Health>();
        _attackDetector = attackDetector;
        _speedCoefficientPersecution = speedCoefficientPersecution;
    }

    public override void Enter()
    {
        EnemyMover.SetTargetToMoveTowards(PersecutionDetector.Targets[0].transform);
        EnemyMover.SetSpeedCoefficient(_speedCoefficientPersecution);


        //_playersInZoneVisible = PersecutionDetector.Targets;
        PersecutionDetector.AvailableTargetAdded += UpdateListPlayersInZoneOfVisibility;
        PersecutionDetector.AvailableTargetRemoved += UpdateListPlayersInZoneOfVisibility;
        _attackDetector.AvailableTargetAdded += TryEnterStateOfPatrolling;
    }

    public override void Update()
    {
        if (_playersInZoneVisible.Count > 0)
        {
            EnemyMover.SetTargetToMoveTowards(_follower.GetNearestPlayerInVisibleZone().transform);

            Flipper.TurnFront(EnemyMover.TargetToMoveTowards.position.x - Transform.position.x);

            if (Mathf.Abs(EnemyMover.TargetToMoveTowards.transform.position.x - Transform.position.x) > _distanceCeasePersecution)
                EnemyMover.Move();
        }
        else
        {
            StateMachine.ChangeState<EnemyStatePatrolling>();
        }
    }

    public override void Exit()
    {
        PersecutionDetector.AvailableTargetAdded -= UpdateListPlayersInZoneOfVisibility;
        PersecutionDetector.AvailableTargetRemoved -= UpdateListPlayersInZoneOfVisibility;
        _attackDetector.AvailableTargetAdded -= TryEnterStateOfPatrolling;
    }

    //private Health GetNearestPlayerInVisibleZone()
    //{
    //    List<Health> playersByDistanceEnemy = new List<Health>(_playersInZoneVisible.OrderBy(p => Mathf.Abs(p.transform.position.x - Transform.position.x)));

    //    return playersByDistanceEnemy[0];
    //}

    //private void UpdateListPlayersInZoneOfVisibility()
    //{
    //    _playersInZoneVisible = PersecutionDetector.Targets;
    //}

    private void TryEnterStateOfPatrolling()
    {
        if (_attackDetector.Targets.Count > 0)
        {
            StateMachine.ChangeState<EnemyStateAttack>();
        }
    }
}