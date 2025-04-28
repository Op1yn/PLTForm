using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    public PlayerStateMachine PlayerStateMachine { get; private set; }
    public InputReader InputReader { get; private set; }

    public PlayerState(PlayerStateMachine playerStateMachine)
    {
        PlayerStateMachine = playerStateMachine;
    }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void Exit() { }
}