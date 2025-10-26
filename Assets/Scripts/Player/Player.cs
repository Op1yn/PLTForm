using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GroundDetector _groundingDetector;
    [SerializeField] private float _speedX;
    [SerializeField] private float _jumpForce;

    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public Rigidbody2D Rigidbody2D { get; private set; }
    [field: SerializeField] public PlayerAnimator Animator { get; private set; }

    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerMover Mover { get; private set; }
    public Flipper Flipper { get; private set; }

    private void Awake()
    {
        Mover = new PlayerMover(Rigidbody2D, _speedX, _jumpForce);
        Flipper = new Flipper(transform);
        StateMachine = new PlayerStateMachine();

        StateMachine.AddState(new PlayerStateIdle(StateMachine, InputReader, _groundingDetector, Animator, Rigidbody2D, Flipper));
        StateMachine.AddState(new PlayerStateMove(StateMachine, Mover, InputReader, _groundingDetector, Animator, transform, Flipper, Rigidbody2D, Flipper));
        StateMachine.AddState(new PlayerStateJump(StateMachine, InputReader, _groundingDetector, Animator, Mover, Rigidbody2D, Flipper));
        StateMachine.AddState(new PlayerStateAttack(StateMachine, InputReader, _groundingDetector, Animator, Rigidbody2D, Flipper));

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