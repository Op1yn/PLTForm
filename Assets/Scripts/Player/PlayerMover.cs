using UnityEngine;

public class PlayerMover
{
    private float _speedX;
    private float _jumpForce;

    private Rigidbody2D _rigidbody;

    public PlayerMover(Rigidbody2D rigidbody, float speedX, float lumpForce)
    {
        _rigidbody = rigidbody;
        _speedX = speedX;
        _jumpForce = lumpForce;
    }

    public void Move(float direction)
    {
        _rigidbody.velocity = new Vector2(_speedX * direction * Time.fixedDeltaTime, _rigidbody.velocity.y);
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}