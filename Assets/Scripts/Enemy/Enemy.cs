using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _patrolSpeed = 1f;
    [SerializeField] private float _persecutionSpeed = 2;
    [SerializeField] private int _damage = 10;
    [SerializeField] private List<Transform> _routePoints;
    [SerializeField] private PlayerDetectionDetector _attackDetector;
    [SerializeField] private PlayerDetectionDetector _persecutionDetector;
    [SerializeField] private EnemyAnimator _animator;

    private EnemyStateMachine _stateMachine;

    public Follower Follower { get; private set; }
    public MoverByPoints MoverByPoints { get; private set; }
    public Flipper Flipper { get; private set; }
    public EnemyDamageDealer DamageDealer { get; private set; }

    private void Start()
    {
        Follower = new Follower(transform, _persecutionSpeed);
        MoverByPoints = new MoverByPoints(transform, _patrolSpeed, _routePoints);
        Flipper = new Flipper(transform);
        DamageDealer = new EnemyDamageDealer(_attackDetector, _damage);

        _stateMachine = new EnemyStateMachine();
        _stateMachine.AddState(new EnemyStatePatrolling(_stateMachine, _animator, _persecutionDetector, MoverByPoints, Flipper));
        _stateMachine.AddState(new EnemyStatePersecution(_stateMachine, _animator, _persecutionDetector, Follower, Flipper, _attackDetector));
        _stateMachine.AddState(new EnemyStateAttack(_stateMachine, _animator, _persecutionDetector, _attackDetector, DamageDealer));
        _stateMachine.ChangeState<EnemyStatePatrolling>();
    }

    private void Update()
    {
        _stateMachine.Update();
    }
}
