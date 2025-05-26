using UnityEngine;

public class PlayerStateJump : PlayerState
{
    private PlayerMover _playerMover;

    public PlayerStateJump(PlayerStateMachine playerStateMachine, InputReader inputReader, GroundDetector groundDetector, PlayerAnimator playerAnimator, PlayerMover playerMover, Rigidbody2D rigidbody2D) : base(playerStateMachine, inputReader, groundDetector, playerAnimator, rigidbody2D)
    {
        _playerMover = playerMover;
    }

    public override void Enter()
    {
        _playerMover.Jump();
        PlayerAnimator.Jump();
        GroundDetector.Landed += SetStatePlayerStateIdle;
    }

    private void SetStatePlayerStateIdle()
    {
        PlayerStateMachine.ChangeState<PlayerStateIdle>();
    }

    public override void Exit()
    {
        PlayerAnimator.StopJump();
        GroundDetector.Landed -= SetStatePlayerStateIdle;
        Rigidbody2D.velocity = Vector3.zero;
    }
}