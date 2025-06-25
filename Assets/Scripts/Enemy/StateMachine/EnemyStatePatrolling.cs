using System.Collections.Generic;
using UnityEngine;

public class EnemyStatePatrolling : EnemyStateMovement
{
    private List<Transform> _routePoints;
    private int _currentPoint;

    public EnemyStatePatrolling(EnemyStateMachine stateMachine, Transform transform, float speed, List<Transform> routePoints, Flipper flipper, PersecutionDetector persecutionDetector, EnemyAnimator enemyAnimator, AttackDetector attackDetector) : base(stateMachine, transform, speed, flipper, persecutionDetector, enemyAnimator, attackDetector)
    {
        _routePoints = routePoints;
    }

    public override void Enter()
    {
        PersecutionDetector.TargetDetected += TryEnterStateOfPersecution;
        _currentPoint = 0;
        SetTargetToMoveTowards(_routePoints[0]);
    }

    public override void Update()
    {
        if (HasPointReached())
            SwitchRoutePoint();

        base.Update();
    }

    public override void Exit()
    {
        PersecutionDetector.TargetDetected -= TryEnterStateOfPersecution;
    }

    private void TryEnterStateOfPersecution()
    {
        List<Player> players = PersecutionDetector.GetPlayersInPersecutionZone();

        if (players.Count != 0)
        {
            StateMachine.ChangeState<EnemyStatePersecution>();
        }
    }

    private bool HasPointReached()
    {
        float pointDistanceReach = 0.2f;
        Vector2 offset = _routePoints[_currentPoint].position - new Vector3(Transform.position.x, Transform.position.y);

        return offset.sqrMagnitude <= pointDistanceReach;
    }

    private void SwitchRoutePoint()
    {
        _currentPoint = (_currentPoint + 1) % _routePoints.Count;
        SetTargetToMoveTowards(_routePoints[_currentPoint]);
    }
}
