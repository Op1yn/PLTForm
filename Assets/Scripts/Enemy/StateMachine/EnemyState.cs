using UnityEngine;

public abstract class EnemyState
{
    protected readonly EnemyStateMachine EnemyStateMachine;
    protected EnemyPersecutionDetector EnemyPersecutionManager;
    protected EnemyAttackDetector EnemyAttackDetector;
    protected EnemyAnimator EnemyAnimator;

    public EnemyState(EnemyStateMachine stateMachine, EnemyPersecutionDetector enemyPersecutionManager, EnemyAttackDetector enemyAttackDetector, EnemyAnimator enemyAnimator)
    {
        EnemyStateMachine = stateMachine;
        EnemyPersecutionManager = enemyPersecutionManager;
        EnemyAttackDetector = enemyAttackDetector;
        EnemyAnimator = enemyAnimator;
    }

    public Transform Target { get; private set; }

    public virtual void Enter(Transform T) { }
    public virtual void Update() { }
    public virtual void Exit() { }

    public virtual void SetTarget(Transform target)
    {
        Target = target;
    }
}
