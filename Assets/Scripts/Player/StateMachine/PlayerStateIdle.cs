public class PlayerStateIdle : PlayerState
{
    public PlayerStateIdle(PlayerStateMachine playerStateMachine, InputReader inputReader, GroundDetector groundDetector, PlayerAnimator playerAnimator) : base(playerStateMachine, inputReader, groundDetector, playerAnimator)
    {
    }

    public override void Exit()
    {
        InputReader.JumpingButtonPressed -= TrySetJumpState;
        InputReader.AttackButtonPressed -= TrySetAttackState;
    }

    public override void Update()
    {
        if (InputReader.Direction != 0 && GroundDetector.IsGround)
        {
            PlayerStateMachine.ChangeState<PlayerStateMove>();
        }
    }

    public override void Enter()
    {
        InputReader.JumpingButtonPressed += TrySetJumpState;
        InputReader.AttackButtonPressed += TrySetAttackState;
    }

    private void TrySetJumpState()
    {
        if (GroundDetector.IsGround)
        {
            PlayerStateMachine.ChangeState<PlayerStateJump>();
        }
    }

    private void TrySetAttackState()
    {
        if (GroundDetector.IsGround)
        {
            PlayerStateMachine.ChangeState<PlayerStateAttack>();
        }
    }
}