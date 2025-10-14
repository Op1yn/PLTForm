using System;
using System.Collections.Generic;

public class EnemyStateMachine
{
    public EnemyState CurrentState { get; private set; }
    private Dictionary<Type, EnemyState> _states = new Dictionary<Type, EnemyState>();

    public void AddState(EnemyState enemyState)
    {
        _states.Add(enemyState.GetType(), enemyState);
    }

    public void ChangeState<T>() where T : EnemyState
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
}