using UnityEngine;

public class PlayerStateMovement : PlayerState
{
    public PlayerStateMovement(PlayerStateMachine playerStateMachine, PlayerMover playerMover, InputReader inputReader, GroundDetector groundDetector, PlayerAnimator playerAnimator, Transform transform) : base(playerStateMachine, inputReader, groundDetector, playerAnimator)
    {
        PlayerMover = playerMover;
    }

    public PlayerMover PlayerMover { get; private set; }
}
