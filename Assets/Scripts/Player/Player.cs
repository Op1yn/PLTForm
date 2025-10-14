using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GroundDetector _groundingDetector;
    [SerializeField] private float _speedX;
    [SerializeField] private float _jumpForce;

    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public Rigidbody2D Rigidbody2D { get; private set; }
    [field: SerializeField] public PlayerAnimator Animator { get; private set; }

    public PlayerStateMachine PlayerStateMachine { get; private set; }
    public PlayerMover Mover { get; private set; }
    public Flipper Flipper { get; private set; }

    private void Awake()
    {
        Mover = new PlayerMover(Rigidbody2D, _speedX, _jumpForce);
        Flipper = new Flipper(transform);
        PlayerStateMachine = new PlayerStateMachine();

        PlayerStateMachine.AddState(new PlayerStateIdle(PlayerStateMachine, InputReader, _groundingDetector, Animator, Rigidbody2D, Flipper));
        PlayerStateMachine.AddState(new PlayerStateMove(PlayerStateMachine, Mover, InputReader, _groundingDetector, Animator, transform, Flipper, Rigidbody2D, Flipper));
        PlayerStateMachine.AddState(new PlayerStateJump(PlayerStateMachine, InputReader, _groundingDetector, Animator, Mover, Rigidbody2D, Flipper));
        PlayerStateMachine.AddState(new PlayerStateAttack(PlayerStateMachine, InputReader, _groundingDetector, Animator, Rigidbody2D, Flipper));

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