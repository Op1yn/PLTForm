using UnityEngine;

public class PlayerFlipper : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    private int reversDirection = 180;

    private void FixedUpdate()
    {
        TurnFront(_inputReader.Direction);
    }

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
