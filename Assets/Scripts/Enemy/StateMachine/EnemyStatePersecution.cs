using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyStatePersecution : EnemyStateMovement
{
    private float _distanceCeasePersecution = 1.2f;
    private List<Player> _playersInZoneVisible;
    private AttackDetector _attackDetector;

    public EnemyStatePersecution(EnemyStateMachine stateMachine, Transform transform, float speed, Flipper flipper, PersecutionDetector enemyPersecutionManager, EnemyAnimator enemyAnimator, AttackDetector attackDetector) : base(stateMachine, transform, speed, flipper, enemyPersecutionManager, enemyAnimator, attackDetector)
    {
        _playersInZoneVisible = new List<Player>();
        _attackDetector = attackDetector;
    }

    public override void Enter()
    {
        _playersInZoneVisible = PersecutionDetector.GetPlayersInPersecutionZone();
        SetTargetToMoveTowards(_playersInZoneVisible[0].transform);
        PersecutionDetector.TargetDetected += UpdateListPlayersInZoneOfVisibility;
        PersecutionDetector.TargetDisappeared += UpdateListPlayersInZoneOfVisibility;
        _attackDetector.AvailableTargetAdded += TryEnterStateOfPatrolling;
    }

    public override void Update()
    {
        if (_playersInZoneVisible.Count > 0)
        {
            SetTargetToMoveTowards(GetNearestPlayerInVisibleZone().transform);

            Flipper.TurnFront(TargetToMoveTowards.position.x - Transform.position.x);

            if (Mathf.Abs(TargetToMoveTowards.transform.position.x - Transform.position.x) > _distanceCeasePersecution)
                Move();
        }
        else
        {
            StateMachine.ChangeState<EnemyStatePatrolling>();
        }
    }

    public override void Exit()
    {
        PersecutionDetector.TargetDetected -= UpdateListPlayersInZoneOfVisibility;
        PersecutionDetector.TargetDisappeared -= UpdateListPlayersInZoneOfVisibility;
        _attackDetector.AvailableTargetAdded -= TryEnterStateOfPatrolling;
    }

    public override void Move()
    {
        Transform.position = Vector2.MoveTowards(Transform.position, new Vector2(TargetToMoveTowards.transform.position.x, Transform.position.y), Speed * Time.deltaTime);
    }

    private Player GetNearestPlayerInVisibleZone()
    {
        List<Player> playersByDistanceEnemy = new List<Player>(_playersInZoneVisible.OrderBy(p => Mathf.Abs(p.transform.position.x - Transform.position.x)));

        return playersByDistanceEnemy[0];
    }

    private void UpdateListPlayersInZoneOfVisibility()
    {
        _playersInZoneVisible = PersecutionDetector.GetPlayersInPersecutionZone();
    }

    private void TryEnterStateOfPatrolling()
    {
        if (_attackDetector.GetPlayersHealthInAttackZone().Count > 0)
        {
            StateMachine.ChangeState<EnemyStateAttack>();
        }
    }
}