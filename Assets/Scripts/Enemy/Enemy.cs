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
    [SerializeField] private Health _health;

    private EnemyStateMachine _stateMachine;
    private EnemyStateMachineFactory _enemyStateMachineFactory;

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
        _enemyStateMachineFactory = new EnemyStateMachineFactory(_animator, _persecutionDetector, Flipper, MoverByPoints, Follower, _attackDetector, DamageDealer);
        _stateMachine = _enemyStateMachineFactory.GatStateMachine();

        _stateMachine.ChangeState<EnemyStatePatrolling>();
    }

    private void OnEnable()
    {
        _health.HealthPointsOver += ToDie;
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    private void OnDisable()
    {
        _health.HealthPointsOver -= ToDie;
    }

    private void ToDie()
    {
        gameObject.SetActive(false);
    }
}