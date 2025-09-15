using System.Collections.Generic;
using UnityEngine;

public class EnemyMover
{
    private List<Transform> _routePoints;
    private int _currentPoint;
    private Transform _transform;
    private float _speed;
    private float _speedCoefficient = 1;
    private float _minimumSpeedFactor = 0f;
    private float _maximumSpeedFactor = 5;

    public Transform TargetToMoveTowards { get; private set; }

    public EnemyMover(Transform transform, float speed, List<Transform> routePoints)
    {
        _routePoints = routePoints;
        _currentPoint = 0;
        _transform = transform;
        _speed = speed;
    }

    //public void Move(Transform target)
    //{
    //    _transform.position = Vector2.MoveTowards(_transform.position, target.position, _speed * Time.deltaTime);
    //}

    public void Move()
    {
        _transform.position = Vector2.MoveTowards(_transform.position, new Vector2(TargetToMoveTowards.transform.position.x, _transform.position.y), _speed * _speedCoefficient * Time.deltaTime);
    }

    public void SetTargetToMoveTowards(Transform target)
    {
        TargetToMoveTowards = target;
    }

    public bool HasPointReached()
    {
        float pointDistanceReach = 0.2f;
        Vector2 offset = _routePoints[_currentPoint].position - new Vector3(_transform.position.x, _transform.position.y);

        return offset.sqrMagnitude <= pointDistanceReach;
    }

    public void SwitchRoutePoint()
    {
        _currentPoint = (_currentPoint + 1) % _routePoints.Count;
        SetTargetToMoveTowards(_routePoints[_currentPoint]);
    }

    public void SetSpeedCoefficient(float factor)
    {
        _speedCoefficient = Mathf.Clamp(factor, _minimumSpeedFactor, _maximumSpeedFactor);
    }
}
