using UnityEngine;

public class PlayerMover : IMoving
{
    private float _speedX;
    private float _jumpForce;
    private float _direction;

    private Rigidbody2D _rigidbody;

    public PlayerMover(Rigidbody2D rigidbody, float speedX, float lumpForce)
    {
        _rigidbody = rigidbody;
        _speedX = speedX;
        _jumpForce = lumpForce;
    }

    public void Move()
    {
        _rigidbody.linearVelocity = new Vector2(_speedX * _direction * Time.fixedDeltaTime, _rigidbody.linearVelocity.y);
    }

    public void SetDirection(float direction)
    {
        _direction = direction;
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    public void LandingStop()
    {
        _rigidbody.linearVelocity = new Vector2(0, 0);
    }
}