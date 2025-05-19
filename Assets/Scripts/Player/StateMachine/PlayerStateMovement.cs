using UnityEngine;

public class PlayerStateMovement : PlayerState
{
    private int reversDirection = 180;
    private Transform _transform;

    public PlayerMover PlayerMover { get; private set; }

    public PlayerStateMovement(PlayerStateMachine playerStateMachine, PlayerMover playerMover, InputReader inputReader, GroundDetector groundDetector, PlayerAnimator playerAnimator, Transform transform) : base(playerStateMachine, inputReader, groundDetector, playerAnimator)
    {
        PlayerMover = playerMover;
        _transform = transform;
    }

    public override void FixedUpdate()
    {
        TurnFront(InputReader.Direction);
    }

    public void TurnFront(float direction)
    {
        if (Mathf.Abs(direction) > 0)
        {
            float directionNormalized = Mathf.Sign(direction);

            if (directionNormalized < 0)
            {
                _transform.rotation = Quaternion.Euler(new Vector2(0, directionNormalized) * reversDirection);
            }
            else
            {
                _transform.rotation = Quaternion.Euler(new Vector2(0, directionNormalized));
            }
        }
    }
}
