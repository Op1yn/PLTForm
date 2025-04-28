using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerDamageDealer _damageDealer;
    [SerializeField] private float _speedX;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;

    public bool WasJumpPressed { get; private set; }
    public bool IsPossibleMove { get; private set; } = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();//Надо будет передать в состояния прыжка и ходьбы
    }

    private void OnEnable()
    {
        _inputReader.JumpBeenPressed += SetIsJump;
        _damageDealer.AttackBegun += NotMoveToAttack;
        _damageDealer.AttackOver += AllowMovements;
    }

    private void OnDisable()
    {
        _inputReader.JumpBeenPressed -= SetIsJump;
        _damageDealer.AttackBegun -= NotMoveToAttack;
        _damageDealer.AttackOver -= AllowMovements;
    }

    public void Move(float direction)
    {
        _rigidbody.velocity = new Vector2(_speedX * direction * Time.fixedDeltaTime, _rigidbody.velocity.y);
    }

    public void Jump()
    {
        WasJumpPressed = false;
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    public void SetIsJump()
    {
        WasJumpPressed = true;
    }

    public void TurnFront(float direction)
    {
        if (Mathf.Abs(direction) > 0)
        {
            int reversDirection = 180;
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

    private void NotMoveToAttack()
    {
        _rigidbody.velocity = Vector2.zero;
        IsPossibleMove = false;
    }

    private void AllowMovements()
    {
        IsPossibleMove = true;
    }
}