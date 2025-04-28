using System;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public event Action Landed;
    public event Action LeavingOffGround;
    public bool IsGround { get; private set; }
    public int AmountTouchesGround { get; private set; } = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
        {
            int amountActiveTouchesGroundForJump = 1;
            AmountTouchesGround++;

            if (AmountTouchesGround == amountActiveTouchesGroundForJump)
            {
                IsGround = true;
                Landed?.Invoke();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
        {
            AmountTouchesGround--;
            IsGround = false;
            LeavingOffGround?.Invoke();
        }
    }
}
