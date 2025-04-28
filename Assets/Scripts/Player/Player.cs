using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GroundDetector _groundingDetector;
    [SerializeField] private PlayerMover _playerMover;

    public PlayerStateMachine PlayerStateMachine { get; private set; }

    private void Start()
    {
        Debug.Log("Start PlayerStateMachine");

        PlayerStateMachine = new PlayerStateMachine();

        PlayerStateMachine.AddState(new PlayerStateIdle(PlayerStateMachine));
        PlayerStateMachine.AddState(new PlayerStateMove(PlayerStateMachine));
        PlayerStateMachine.AddState(new PlayerStateJump(PlayerStateMachine));

        PlayerStateMachine.SetState<PlayerStateIdle>();
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