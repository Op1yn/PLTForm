using UnityEngine;

public class PlayerStateIdle : PlayerState
{
    public PlayerStateIdle(PlayerStateMachine playerStateMachine, InputReader inputReader, GroundDetector groundDetector, PlayerAnimator playerAnimator) : base(playerStateMachine, inputReader, groundDetector, playerAnimator)
    {
    }

    public override void Enter()
    {
        InputReader.JumpingButtonPressed += TrySetJumpState;
        InputReader.AttackButtonPressed += TrySetAttackState;
    }

    public override void Update()
    {
        if (InputReader.Direction != 0)
        {
            PlayerStateMachine.SetState<PlayerStateMove>();
        }
    }

    private void TrySetJumpState()
    {
        if (GroundDetector.IsGround)
        {
            PlayerStateMachine.SetState<PlayerStateJump>();
        }
    }

    private void TrySetAttackState()
    {
        if (GroundDetector.IsGround)
        {
            PlayerStateMachine.SetState<PlayerStateAttack>();
        }
    }

    public override void Exit()
    {
        InputReader.JumpingButtonPressed -= TrySetJumpState;
        InputReader.AttackButtonPressed -= TrySetAttackState;
    }
}