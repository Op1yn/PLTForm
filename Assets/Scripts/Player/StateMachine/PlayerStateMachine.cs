using System;
using System.Collections.Generic;

public class PlayerStateMachine
{
    private PlayerState _currentState;
    private Dictionary<Type, PlayerState> _states = new Dictionary<Type, PlayerState>();

    public void AddState(PlayerState playerState)
    {
        _states.Add(playerState.GetType(), playerState);
    }

    public void ChangeState<T>() where T : PlayerState
    {
        var type = typeof(T);

        if (_currentState != null && _currentState.GetType() == type)
            return;

        if (_states.TryGetValue(type, out var newState))
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }
    }

    public void Update()
    {
        _currentState?.Update();
    }

    public void FixedUpdate()
    {
        _currentState?.FixedUpdate();
    }
}
