using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
    private EnemyState CurrentState { get; set; }
    private Dictionary<Type, EnemyState> _states = new Dictionary<Type, EnemyState>();

    public void AddState(EnemyState _enemyState)
    {
        _states.Add(_enemyState.GetType(), _enemyState);
    }

    public void SetState<T>(Transform target) where T : EnemyState
    {
        var type = typeof(T);

        if (CurrentState != null && CurrentState.GetType() == type)
            return;

        if (_states.TryGetValue(type, out var newState))
        {
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter(target);
        }
    }

    public void Update()
    {
        CurrentState?.Update();
    }
}
