using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GroundDetector _groundingDetector;
    [SerializeField] private float _speedX;
    [SerializeField] private float _jumpForce;


    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
    [field: SerializeField] public PlayerAnimator PlayerAnimator { get; private set; }
    [field: SerializeField] public Flipper Flipper { get; private set; }
    public PlayerStateMachine PlayerStateMachine { get; private set; }
    public PlayerMover PlayerMover { get; private set; }

    private void Start()
    {
        PlayerMover = new PlayerMover(Rigidbody, _speedX, _jumpForce);
        PlayerStateMachine = new PlayerStateMachine();

        PlayerStateMachine.AddState(new PlayerStateIdle(PlayerStateMachine, InputReader, _groundingDetector, PlayerAnimator));
        PlayerStateMachine.AddState(new PlayerStateMove(PlayerStateMachine, PlayerMover, InputReader, _groundingDetector, PlayerAnimator, transform, Flipper));
        PlayerStateMachine.AddState(new PlayerStateJump(PlayerStateMachine, InputReader, _groundingDetector, PlayerAnimator, PlayerMover));
        PlayerStateMachine.AddState(new PlayerStateAttack(PlayerStateMachine, InputReader, _groundingDetector, PlayerAnimator));

        PlayerStateMachine.ChangeState<PlayerStateIdle>();
    }

    private void Update()
    {
        PlayerStateMachine.Update();
    }

    private void FixedUpdate()
    {
        PlayerStateMachine.FixedUpdate();

        //if (_playerMover.IsPossibleMove)
        //{
        //    if (_inputReader.Direction != 0)
        //    {
        //        _playerMover.TurnFront(_inputReader.Direction);
        //        _playerMover.Move(_inputReader.Direction);
        //    }

        //    if (_playerMover.WasJumpPressed && _groundingDetector.IsGround)
        //    {
        //        _playerMover.Jump();
        //    }
        //}
    }
}