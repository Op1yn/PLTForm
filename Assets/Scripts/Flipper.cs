using UnityEngine;

public class Flipper : MonoBehaviour
{
    private int reversDirection = 180;

    public void TurnFront(float direction)
    {
        if (Mathf.Abs(direction) > 0)
        {
            float directionNormalized = Mathf.Sign(direction);

            if (directionNormalized < 0)
            {
                transform.rotation = Quaternion.Euler(new Vector2(0, directionNormalized) * reversDirection);
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector2(0, directionNormalized));
            }
        }
    }
}
