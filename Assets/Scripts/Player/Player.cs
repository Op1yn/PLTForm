using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GroundDetector _groundingDetector;
    [SerializeField] private float _speedX;
    [SerializeField] private float _jumpForce;

    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public Rigidbody2D Rigidbody2D { get; private set; }
    [field: SerializeField] public PlayerAnimator Animator { get; private set; }

    private PlayerStateMachineFactory _stateMachineFactory;

    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerMover Mover { get; private set; }
    public Flipper Flipper { get; private set; }

    private void Awake()
    {
        Mover = new PlayerMover(Rigidbody2D, _speedX, _jumpForce);
        Flipper = new Flipper(transform);

        _stateMachineFactory = new PlayerStateMachineFactory(InputReader, _groundingDetector, Animator, Rigidbody2D, Flipper, Mover, transform);
        StateMachine = _stateMachineFactory.GatStateMachine();

        StateMachine.ChangeState<PlayerStateIdle>();
    }

    private void Update()
    {
        StateMachine.Update();
    }

    private void FixedUpdate()
    {
        StateMachine.FixedUpdate();
    }
}