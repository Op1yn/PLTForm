public class PlayerStateJump : PlayerState
{
    private PlayerMover _playerMover;

    public PlayerStateJump(PlayerStateMachine playerStateMachine, InputReader inputReader, GroundDetector groundDetector, PlayerAnimator playerAnimator, PlayerMover playerMover) : base(playerStateMachine, inputReader, groundDetector, playerAnimator)
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
    }
}