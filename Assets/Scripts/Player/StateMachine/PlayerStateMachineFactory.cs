using UnityEngine;

public class PlayerStateMachineFactory
{
    private PlayerStateMachine _tateMachine;

    public PlayerStateMachineFactory(InputReader inputReader, GroundDetector groundDetector, PlayerAnimator animator, Rigidbody2D rigidbody2D, Flipper flipper, PlayerMover mover, Transform transform)
    {
        _tateMachine = new PlayerStateMachine();

        _tateMachine.AddState(new PlayerStateIdle(_tateMachine, inputReader, groundDetector, animator, rigidbody2D, flipper));
        _tateMachine.AddState(new PlayerStateMove(_tateMachine, mover, inputReader, groundDetector, animator, transform, flipper, rigidbody2D, flipper));
        _tateMachine.AddState(new PlayerStateJump(_tateMachine, inputReader, groundDetector, animator, mover, rigidbody2D, flipper));
        _tateMachine.AddState(new PlayerStateAttack(_tateMachine, inputReader, groundDetector, animator, rigidbody2D, flipper));
    }

    public PlayerStateMachine GatStateMachine()
    {
        return _tateMachine;
    }
}
