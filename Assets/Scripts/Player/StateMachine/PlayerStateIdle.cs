using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateIdle : PlayerState
{
    private const string Horizontal = "Horizontal";

    public PlayerStateIdle(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Update()
    {
        
        if (Input.GetAxis(Horizontal) != 0)
        {
            Debug.Log(".GetAxis(Horizontal) != 0");
            PlayerStateMachine.SetState<PlayerStateMove>();
            //_playerMover.TurnFront(_inputReader.Direction);
            //_playerMover.Move(_inputReader.Direction);
        }

        if (Input.GetKeyDown(KeyCode.Space) /*&& _groundingDetector.IsGround*/)//������ ���� ����������� �� ��������� ���� - ������ �� �����, � ������ �� ��������� ������, ��� ���� ����� ��� �������� ������ � �������. �������� � ������� ������ ����� ����� ���������� Direction �� InputReader.
        {
            PlayerStateMachine.SetState<PlayerStateJump>();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
        }
    }

    public override void FixedUpdate()
    {

    }
}