using UnityEngine;

public class Follower : IMoving
{
    private float _speed;

    public Transform Transform;
    public Transform TargetToMoveTowards { get; private set; }

    public Follower(Transform transform, float speed)
    {
        Transform = transform;
        _speed = speed;
    }

    public void SetTargetToMoveTowards(Transform target)
    {
        TargetToMoveTowards = target;
    }

    public void Move()
    {
        Transform.position = Vector2.MoveTowards(Transform.position, new Vector2(TargetToMoveTowards.transform.position.x, Transform.position.y), _speed * Time.deltaTime);
    }
}
