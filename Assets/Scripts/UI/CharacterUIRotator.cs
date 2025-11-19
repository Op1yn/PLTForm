using UnityEngine;

public class CharacterUIRotator : MonoBehaviour
{
    [SerializeField] private Transform _characterTransform;

    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(new Vector2(0, _characterTransform.rotation.y));
    }
}
