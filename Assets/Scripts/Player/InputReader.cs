using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";

    public event Action JumpBeenPressed;
    public event Action AttackButtonBeenPressed;
    
    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpBeenPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            AttackButtonBeenPressed?.Invoke();
        }
    }
}