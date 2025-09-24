using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _patrolSpeed = 1f;
    [SerializeField] private float _speedCoefficientPersecution = 2;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private List<Transform> _routePoints;
    [SerializeField] private EnemyDetector _attackDetector;
    [SerializeField] private EnemyDetector _persecutionDetector;
    [SerializeField] private EnemyDamageDealer _enemyDamageDealer;
    [SerializeField] private EnemyAnimator _enemyAnimator;

    private EnemyStateMachine _enemyStateMachine;

    public EnemyMover EnemyMover { get; private set; }
    public Follower Follower { get; private set; }

    private void Start()
    {
        EnemyMover = new EnemyMover(this.transform, _patrolSpeed, _routePoints);
        Follower = new Follower();
        _enemyStateMachine = new EnemyStateMachine();

        _enemyStateMachine.AddState(new EnemyStatePatrolling(_enemyStateMachine, transform, _flipper, _persecutionDetector, _enemyAnimator, _attackDetector, EnemyMover));
        _enemyStateMachine.AddState(new EnemyStatePersecution(_enemyStateMachine, transform, _flipper, _persecutionDetector, _enemyAnimator, _attackDetector, EnemyMover, _speedCoefficientPersecution, Follower));
        _enemyStateMachine.AddState(new EnemyStateAttack(_enemyStateMachine, _flipper, _persecutionDetector, _enemyAnimator, _attackDetector, _enemyDamageDealer));

        _enemyStateMachine.ChangeState<EnemyStatePatrolling>();
    }

    private void Update()
    {
        _enemyStateMachine.Update();
    }
}
