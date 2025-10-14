using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";

    public event Action JumpingButtonPressed;
    public event Action AttackButtonPressed;

    public float Direction { get; private set; }
    public float LastDirectionOfMoving { get; private set; } = 0;
    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);

        if (Direction != 0)
        {
            LastDirectionOfMoving = Direction;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpingButtonPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            AttackButtonPressed?.Invoke();
        }
    }
}