using UnityEngine;

public class PlayerState
{
    public PlayerState(PlayerStateMachine playerStateMachine, InputReader inputReader, GroundDetector groundDetector, PlayerAnimator playerAnimator, Rigidbody2D rigidbody2D, Flipper flipper)
    {
        PlayerStateMachine = playerStateMachine;
        InputReader = inputReader;
        GroundDetector = groundDetector;
        PlayerAnimator = playerAnimator;
        Rigidbody2D = rigidbody2D;
        Flipper = flipper;
    }

    public PlayerStateMachine PlayerStateMachine { get; private set; }
    public InputReader InputReader { get; private set; }
    public GroundDetector GroundDetector { get; private set; }
    public PlayerAnimator PlayerAnimator { get; private set; }
    public Rigidbody2D Rigidbody2D { get; private set; }
    public Flipper Flipper { get; private set; }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void Exit() { }
}