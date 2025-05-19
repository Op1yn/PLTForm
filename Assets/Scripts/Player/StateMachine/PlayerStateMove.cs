using UnityEngine;

public class PlayerStateMove : PlayerStateMovement
{
    public PlayerStateMove(PlayerStateMachine playerStateMachine, PlayerMover playerMover, InputReader inputReader, GroundDetector groundDetector, PlayerAnimator playerAnimator, Transform transform) : base(playerStateMachine, playerMover, inputReader, groundDetector, playerAnimator, transform)
    {
    }

    public override void Enter()
    {
        InputReader.JumpingButtonPressed += TrySetJumpState;
        InputReader.AttackButtonPressed += TrySetAttackState;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        PlayerMover.Move(InputReader.Direction);

        if (InputReader.Direction == 0)
        {
            PlayerStateMachine.SetState<PlayerStateIdle>();
        }

        PlayerAnimator.SetSpeed(InputReader.Direction);
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
        PlayerAnimator.SetSpeed(0);
        InputReader.JumpingButtonPressed -= TrySetJumpState;
        InputReader.AttackButtonPressed -= TrySetAttackState;
    }
}