using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _patrolSpeed = 2f;
    [SerializeField] private float _pursuitSpeed = 4f;
    [SerializeField] private int _damage = 25;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private EnemyPersecutionDetector _enemyPersecutionManager;
    [SerializeField] private List<Transform> _routePoints;
    [SerializeField] private EnemyAttackDetector _enemyAttackDetector;
    [SerializeField] private EnemyAnimator _enemyAnimator;

    private EnemyStateMachine _enemyStateMachine;

    private void Start()
    {
        _enemyStateMachine = new EnemyStateMachine();

        _enemyStateMachine.AddState(new EnemyStatePatrolling(_enemyStateMachine, transform, _patrolSpeed, _routePoints, _flipper, _enemyPersecutionManager, _enemyAttackDetector, _enemyAnimator));
        _enemyStateMachine.AddState(new EnemyStatePersecution(_enemyStateMachine, transform, _pursuitSpeed, _flipper, _enemyPersecutionManager, _enemyAttackDetector, _enemyAnimator));
        _enemyStateMachine.AddState(new EnemyStateAttack(_enemyStateMachine, _flipper, _enemyPersecutionManager, _enemyAttackDetector, _enemyAnimator));

        _enemyStateMachine.SetState<EnemyStatePatrolling>(_routePoints[0]);
    }

    private void Update()
    {
        _enemyStateMachine.Update();
    }
}
