using UnityEngine;

public class PlayerStateAttack : PlayerState
{
    private float _timeLastStrike = 0;
    private float _delayBetweenAttacks = 0.5f;

    public PlayerStateAttack(PlayerStateMachine playerStateMachine, InputReader inputReader, GroundDetector groundDetector, PlayerAnimator playerAnimator, Rigidbody2D rigidbody2D) : base(playerStateMachine, inputReader, groundDetector, playerAnimator, rigidbody2D)
    {
    }

    public override void Enter()
    {
        _timeLastStrike = Time.time;
        PlayerAnimator.StartAttack();
    }

    public override void Update()
    {
        if (_timeLastStrike + _delayBetweenAttacks < Time.time)
        {
            PlayerAnimator.StopAttack();
            PlayerStateMachine.ChangeState<PlayerStateIdle>();
        }
    }
}
