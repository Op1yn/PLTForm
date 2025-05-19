using System;
using System.Collections.Generic;

public class PlayerStateMachine
{
    private PlayerState CurrentState { get; set; }
    private Dictionary<Type, PlayerState> _states = new Dictionary<Type, PlayerState>();

    public void AddState(PlayerState playerState)
    {
        _states.Add(playerState.GetType(), playerState);
    }

    public void SetState<T>() where T : PlayerState
    {
        var type = typeof(T);

        if (CurrentState != null && CurrentState.GetType() == type)
            return;

        if (_states.TryGetValue(type, out var newState))
        {
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }

    public void Update()
    {
        CurrentState?.Update();
    }

    public void FixedUpdate()
    {
        CurrentState?.FixedUpdate();
    }
}
