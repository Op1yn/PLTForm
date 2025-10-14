using System.Collections.Generic;
using UnityEngine;

public class MoverByPoints : Follower
{
    private List<Transform> _routePoints;
    private int _currentPoint;

    public MoverByPoints(Transform transform, float speed, List<Transform> RoutePoints) : base(transform, speed)
    {
        _routePoints = RoutePoints;
        _currentPoint = 0;
        SetTargetToMoveTowards(_routePoints[_currentPoint]);
    }

    public bool HasPointReached()
    {
        float pointDistanceReach = 0.2f;
        Vector2 offset = TargetToMoveTowards.position - new Vector3(Transform.position.x, Transform.position.y);

        return offset.sqrMagnitude <= pointDistanceReach;
    }

    public void SetNextPointAsTarget()
    {
        int nextPoint = (_currentPoint + 1) % _routePoints.Count;
        SetTargetToMoveTowards(_routePoints[nextPoint]);
        _currentPoint = nextPoint;
    }
}
