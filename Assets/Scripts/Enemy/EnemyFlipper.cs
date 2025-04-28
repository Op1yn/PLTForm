using UnityEngine;

public class EnemyFlipper : MonoBehaviour
{
    private Transform _target;
    private float _negativeDirectionY = 180;
    private Vector2 _positiveDirection;
    private Vector2 _negativeDirection;

    private void Start()
    {
        _positiveDirection = new Vector2(0, 0);
        _negativeDirection = new Vector2(0, _negativeDirectionY);
    }

    private void FixedUpdate()
    {
        TurnFront();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void TurnFront()
    {
        if (_target.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(_positiveDirection);
        }
        else
        {
            transform.rotation = Quaternion.Euler(_negativeDirection);
        }
    }
}