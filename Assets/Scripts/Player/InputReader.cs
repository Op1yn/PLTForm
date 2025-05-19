using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";

    public event Action JumpingButtonPressed;
    public event Action AttackButtonPressed;
    
    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);

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