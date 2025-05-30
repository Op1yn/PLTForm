using System.Collections.Generic;
using UnityEngine;

public class EnemyStatePatrolling : EnemyStateMovement
{
    private List<Transform> _routePoints;
    private int _currentPoint;

    public EnemyStatePatrolling(EnemyStateMachine stateMachine, Transform transform, float speed, List<Transform> routePoints, Flipper flipper, EnemyPersecutionDetector enemyPersecutionManager, EnemyAnimator enemyAnimator, AttackDetector attackDetector) : base(stateMachine, transform, speed, flipper, enemyPersecutionManager, enemyAnimator, attackDetector)
    {
        _routePoints = routePoints;
    }

    public override void Enter()
    {
        Debug.Log("Патрулирование");
        EnemyPersecutionDetector.PlayerDetected += EnterStateOfPersecution;
        _currentPoint = 0;
        SetTarget(_routePoints[0]);
    }

    public override void Update()
    {
        if (HasPointReached())
            SwitchRoutePoint();

        base.Update();
    }

    public override void Exit()
    {
        EnemyPersecutionDetector.PlayerDetected -= EnterStateOfPersecution;
    }

    private void EnterStateOfPersecution()
    {
        EnemyStateMachine.ChangeState<EnemyStatePersecution>();
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
