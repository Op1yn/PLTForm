using UnityEngine;

public class PlayerStateMove : PlayerState
{
    public PlayerStateMove(PlayerStateMachine playerStateMachine, PlayerMover playerMover, InputReader inputReader, GroundDetector groundDetector, PlayerAnimator playerAnimator, Transform transform, Flipper flipper, Rigidbody2D rigidbody2D, Flipper flipper1) : base(playerStateMachine, inputReader, groundDetector, playerAnimator, rigidbody2D, flipper)
    {
        PlayerMover = playerMover;
    }

    public PlayerMover PlayerMover { get; private set; }

    public override void Enter()
    {
        InputReader.JumpingButtonPressed += TrySetJumpState;
        InputReader.AttackButtonPressed += TrySetAttackState;
    }

    public override void Update()
    {
        Flipper.TurnFrontSelectedDirection(InputReader.Direction);
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

        PlayerMover.SetDirection(InputReader.Direction);
        PlayerMover.Move();

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