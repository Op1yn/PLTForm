using UnityEngine;

public class PlayerStateMovement : PlayerState
{
    public PlayerStateMovement(PlayerStateMachine playerStateMachine, PlayerMover playerMover, InputReader inputReader, GroundDetector groundDetector, PlayerAnimator playerAnimator, Transform transform, Rigidbody2D rigidbody2D) : base(playerStateMachine, inputReader, groundDetector, playerAnimator, rigidbody2D)
    {
        PlayerMover = playerMover;
    }

    public PlayerMover PlayerMover { get; private set; }
}
