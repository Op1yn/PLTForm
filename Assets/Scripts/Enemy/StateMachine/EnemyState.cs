using UnityEngine;

public abstract class EnemyState
{
    protected readonly EnemyStateMachine _enemyStateMachine;
    protected EnemyFlipper _enemyFlipper;
    protected EnemyPersecutionDetector _enemyPersecutionManager;
    protected EnemyAttackDetector _enemyAttackDetector;
    protected EnemyAnimator _enemyAnimator;

    public Transform Target { get; private set; }

    public EnemyState(EnemyStateMachine stateMachine, EnemyFlipper enemyFlipper, EnemyPersecutionDetector enemyPersecutionManager, EnemyAttackDetector enemyAttackDetector, EnemyAnimator enemyAnimator)
    {
        _enemyStateMachine = stateMachine;
        _enemyFlipper = enemyFlipper;
        _enemyPersecutionManager = enemyPersecutionManager;
        _enemyAttackDetector = enemyAttackDetector;
        _enemyAnimator = enemyAnimator;
    }

    public virtual void Enter(Transform T) { }
    public virtual void Update() { }
    public virtual void Exit() { }

    public virtual void SetTarget(Transform target)
    {
        if (target == null)
        {
            Debug.Log("Таргет Налл");

        }

        Target = target;
        _enemyFlipper.SetTarget(Target);
    }
}
