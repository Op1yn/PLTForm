using UnityEngine;

public class PlayerStateIdle : PlayerState
{
    public PlayerStateIdle(PlayerStateMachine playerStateMachine, InputReader inputReader, GroundDetector groundDetector, PlayerAnimator playerAnimator, Rigidbody2D rigidbody2D, Flipper flipper) : base(playerStateMachine, inputReader, groundDetector, playerAnimator, rigidbody2D, flipper)
    {
    }

    public override void Enter()
    {
        InputReader.JumpingButtonPressed += TrySetJumpState;
        InputReader.AttackButtonPressed += TrySetAttackState;
    }

    public override void Update()
    {
        if (InputReader.Direction != 0 && GroundDetector.IsGround)
        {
            PlayerStateMachine.ChangeState<PlayerStateMove>();
        }
        else
        {
            Flipper.TurnFrontSelectedDirection(InputReader.LastDirectionOfMoving);
        }
    }

    public override void Exit()
    {
        InputReader.JumpingButtonPressed -= TrySetJumpState;
        InputReader.AttackButtonPressed -= TrySetAttackState;
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