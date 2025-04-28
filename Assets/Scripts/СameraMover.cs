using UnityEngine;

public class СameraMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothSpeed = 1f;
    [SerializeField] private Vector3 _offset;

    private void LateUpdate()
    {
        Vector3 desiredPosition = _target.position + _offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);

        transform.position = smoothedPosition;
    }
}
