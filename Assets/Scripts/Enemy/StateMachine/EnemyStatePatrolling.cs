using System.Collections.Generic;
using UnityEngine;

public class EnemyStatePatrolling : EnemyStateMovement
{
    private List<Transform> _routePoints;
    private int _currentPoint = 0;

    public EnemyStatePatrolling(EnemyStateMachine stateMachine, Transform transform, float speed, List<Transform> routePoints, Flipper flipper, EnemyPersecutionDetector enemyPersecutionManager, EnemyAttackDetector enemyAttackDetector, EnemyAnimator enemyAnimator) : base(stateMachine, transform, speed, flipper, enemyPersecutionManager, enemyAttackDetector, enemyAnimator)
    {
        _routePoints = routePoints;

        SetTarget(_routePoints[0]);
    }

    public override void Update()
    {
        if (HasPointReached())
            SwitchRoutePoint();

        if (EnemyPersecutionManager.TryGetPlayerTransform(out Transform target))
        {
            EnemyStateMachine.SetState<EnemyStatePersecution>(target);

            return;
        }

        base.Update();
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
        SetTarget(_routePoints[_currentPoint]);
    }
}
