using UnityEngine;

public class Flipper : MonoBehaviour
{
    private int _positiveRotationY = 0;
    private int _negativeRotationY = -180;

    public void TurnFront(float direction)
    {
        if (Mathf.Sign(direction) > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector2(0, _positiveRotationY));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector2(0, _negativeRotationY));
        }
    }
}