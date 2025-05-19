using System.Collections.Generic;
using UnityEngine;

public class EnemyStatePatrolling : EnemyStateMovement
{
    private List<Transform> _routePoints;
    private int _currentPoint = 0;

    public EnemyStatePatrolling(EnemyStateMachine stateMachine, Transform transform, float speed, List<Transform> routePoints, EnemyFlipper enemyFlipper, EnemyPersecutionDetector enemyPersecutionManager, EnemyAttackDetector enemyAttackDetector, EnemyAnimator enemyAnimator) : base(stateMachine, transform, speed, enemyFlipper, enemyPersecutionManager, enemyAttackDetector, enemyAnimator)
    {
        _routePoints = routePoints;

        SetTarget(_routePoints[0]);
    }

    public override void Update()
    {
        if (HasPointReached())
            SwitchRoutePoint();

        if (_enemyPersecutionManager.TryGetPlayerTransform(out Transform target))
        {
            _enemyStateMachine.SetState<EnemyStatePersecution>(target);

            return;
        }

        base.Update();
    }


    private bool HasPointReached()
    {
        float pointDistanceReach = 0.2f;
        Vector2 offset = _routePoints[_currentPoint].position - new Vector3(_transform.position.x, _transform.position.y);

        return offset.sqrMagnitude <= pointDistanceReach;
    }

    private void SwitchRoutePoint()
    {
        _currentPoint = (_currentPoint + 1) % _routePoints.Count;
        SetTarget(_routePoints[_currentPoint]);
    }
}
