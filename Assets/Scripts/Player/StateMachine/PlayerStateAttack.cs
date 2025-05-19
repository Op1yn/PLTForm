using UnityEngine;

public class PlayerStateAttack : PlayerState
{
    private float _timeLastStrike = 0;
    private float _delayBetweenAttacks = 0.5f;

    public PlayerStateAttack(PlayerStateMachine playerStateMachine, InputReader inputReader, GroundDetector groundDetector, PlayerAnimator playerAnimator) : base(playerStateMachine, inputReader, groundDetector, playerAnimator)
    {
    }

    public override void Enter()
    {
        _timeLastStrike = Time.time;
        PlayerAnimator.StartAttackAnimation();
    }

    public override void Update()
    {
        if (_timeLastStrike + _delayBetweenAttacks < Time.time)
        {
            PlayerAnimator.StopAttackAnimation();
            PlayerStateMachine.SetState<PlayerStateIdle>();
        }
    }
}
