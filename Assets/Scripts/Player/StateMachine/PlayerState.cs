public class PlayerState
{
    public PlayerStateMachine PlayerStateMachine { get; private set; }
    public InputReader InputReader { get; private set; }
    public GroundDetector GroundDetector { get; private set; }
    public PlayerAnimator PlayerAnimator { get; private set; }

    public PlayerState(PlayerStateMachine playerStateMachine, InputReader inputReader, GroundDetector groundDetector, PlayerAnimator playerAnimator)
    {
        PlayerStateMachine = playerStateMachine;
        InputReader = inputReader;
        GroundDetector = groundDetector;
        PlayerAnimator = playerAnimator;
    }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void Exit() { }
}