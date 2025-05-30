using System;
using System.Collections.Generic;

public class EnemyStateMachine
{
    private EnemyState _currentState;
    private Dictionary<Type, EnemyState> _states = new Dictionary<Type, EnemyState>();

    public void AddState(EnemyState _enemyState)
    {
        _states.Add(_enemyState.GetType(), _enemyState);
    }

    public void ChangeState<T>() where T : EnemyState
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
}
