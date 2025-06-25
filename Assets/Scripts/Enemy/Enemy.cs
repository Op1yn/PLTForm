using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _patrolSpeed = 2f;
    [SerializeField] private float _persecutionSpeed = 4f;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private List<Transform> _routePoints;
    [SerializeField] private AttackDetector _attackDetector;
    [SerializeField] private PersecutionDetector _persecutionDetector;
    [SerializeField] private EnemyDamageDealer _enemyDamageDealer;
    [SerializeField] private EnemyAnimator _enemyAnimator;

    private EnemyStateMachine _enemyStateMachine;

    private void Start()
    {
        _enemyStateMachine = new EnemyStateMachine();

        _enemyStateMachine.AddState(new EnemyStatePatrolling(_enemyStateMachine, transform, _patrolSpeed, _routePoints, _flipper, _persecutionDetector, _enemyAnimator, _attackDetector));
        _enemyStateMachine.AddState(new EnemyStatePersecution(_enemyStateMachine, transform, _persecutionSpeed, _flipper, _persecutionDetector, _enemyAnimator, _attackDetector));
        _enemyStateMachine.AddState(new EnemyStateAttack(_enemyStateMachine, _flipper, _persecutionDetector, _enemyAnimator, _attackDetector, _enemyDamageDealer));

        _enemyStateMachine.ChangeState<EnemyStatePatrolling>();
    }

    private void Update()
    {
        _enemyStateMachine.Update();
    }
}
