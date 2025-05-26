using UnityEngine;

public class PlayerStateMove : PlayerStateMovement
{
    private Flipper _flipper;

    public PlayerStateMove(PlayerStateMachine playerStateMachine, PlayerMover playerMover, InputReader inputReader, GroundDetector groundDetector, PlayerAnimator playerAnimator, Transform transform, Flipper flipper, Rigidbody2D rigidbody2D) : base(playerStateMachine, playerMover, inputReader, groundDetector, playerAnimator, transform, rigidbody2D)
    {
        _flipper = flipper;
    }

    public override void Enter()
    {
        InputReader.JumpingButtonPressed += TrySetJumpState;
        InputReader.AttackButtonPressed += TrySetAttackState;
    }

    public override void Update()
    {
        _flipper.TurnFront(InputReader.Direction);
    }

    public override void Exit()
    {
        PlayerAnimator.SetSpeed(0);
        InputReader.JumpingButtonPressed -= TrySetJumpState;
        InputReader.AttackButtonPressed -= TrySetAttackState;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        PlayerMover.Move(InputReader.Direction);

        if (InputReader.Direction == 0)
        {
            PlayerStateMachine.ChangeState<PlayerStateIdle>();
        }

        PlayerAnimator.SetSpeed(InputReader.Direction);
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