using UnityEngine;

public class Flipper
{
    private Transform _transform;
    private int _positiveRotationY = 0;
    private int _negativeRotationY = -180;

    public Flipper(Transform transform)
    {
        _transform = transform;
    }

    public void TurnFrontTowardsTarget(Transform targetTransform)
    {
        if (Mathf.Sign(targetTransform.position.x - _transform.position.x) > 0)
        {
            _transform.rotation = Quaternion.Euler(new Vector2(0, _positiveRotationY));
        }
        else
        {
            _transform.rotation = Quaternion.Euler(new Vector2(0, _negativeRotationY));
        }
    }

    public void TurnFrontSelectedDirection(float direction)
    {
        if (Mathf.Sign(direction) > 0)
        {
            _transform.rotation = Quaternion.Euler(new Vector2(0, _positiveRotationY));
        }
        else
        {
            _transform.rotation = Quaternion.Euler(new Vector2(0, _negativeRotationY));
        }
    }
}