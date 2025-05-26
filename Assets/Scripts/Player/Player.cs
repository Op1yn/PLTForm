using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GroundDetector _groundingDetector;
    [SerializeField] private float _speedX;
    [SerializeField] private float _jumpForce;

    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public Rigidbody2D Rigidbody2D { get; private set; }
    [field: SerializeField] public PlayerAnimator PlayerAnimator { get; private set; }
    [field: SerializeField] public Flipper Flipper { get; private set; }

    public PlayerStateMachine PlayerStateMachine { get; private set; }
    public PlayerMover PlayerMover { get; private set; }

    private void Start()
    {
        PlayerMover = new PlayerMover(Rigidbody2D, _speedX, _jumpForce);
        PlayerStateMachine = new PlayerStateMachine();

        PlayerStateMachine.AddState(new PlayerStateIdle(PlayerStateMachine, InputReader, _groundingDetector, PlayerAnimator, Rigidbody2D));
        PlayerStateMachine.AddState(new PlayerStateMove(PlayerStateMachine, PlayerMover, InputReader, _groundingDetector, PlayerAnimator, transform, Flipper, Rigidbody2D));
        PlayerStateMachine.AddState(new PlayerStateJump(PlayerStateMachine, InputReader, _groundingDetector, PlayerAnimator, PlayerMover, Rigidbody2D));
        PlayerStateMachine.AddState(new PlayerStateAttack(PlayerStateMachine, InputReader, _groundingDetector, PlayerAnimator, Rigidbody2D));

        PlayerStateMachine.ChangeState<PlayerStateIdle>();
    }

    private void Update()
    {
        PlayerStateMachine.Update();
    }

    private void FixedUpdate()
    {
        PlayerStateMachine.FixedUpdate();
    }
}