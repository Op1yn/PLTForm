using UnityEngine;

public class PlayerStateJump : PlayerState
{
    private PlayerMover _mover;

    public PlayerStateJump(PlayerStateMachine playerStateMachine, InputReader inputReader, GroundDetector groundDetector, PlayerAnimator playerAnimator, PlayerMover playerMover, Rigidbody2D rigidbody2D, Flipper flipper) : base(playerStateMachine, inputReader, groundDetector, playerAnimator, rigidbody2D, flipper)
    {
        _mover = playerMover;
    }

    public override void Enter()
    {
        _mover.Jump();
        PlayerAnimator.Jump();
        GroundDetector.Landed += SetStatePlayerStateIdle;
    }

    public override void Exit()
    {
        PlayerAnimator.StopJump();
        GroundDetector.Landed -= SetStatePlayerStateIdle;
    }

    private void SetStatePlayerStateIdle()
    {
        _mover.LandingStop();
        PlayerStateMachine.ChangeState<PlayerStateIdle>();
    }
}