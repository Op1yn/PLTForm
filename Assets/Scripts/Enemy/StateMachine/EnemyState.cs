using UnityEngine;

public abstract class EnemyState
{
    protected readonly EnemyStateMachine EnemyStateMachine;
    protected EnemyPersecutionDetector EnemyPersecutionDetector;
    protected EnemyAnimator EnemyAnimator;

    public EnemyState(EnemyStateMachine stateMachine, EnemyPersecutionDetector enemyPersecutionManager, EnemyAnimator enemyAnimator, AttackDetector attackDetector)
    {
        EnemyStateMachine = stateMachine;
        EnemyPersecutionDetector = enemyPersecutionManager;
        EnemyAnimator = enemyAnimator;
    }

    public Transform Target { get; private set; }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }

    public virtual void SetTarget(Transform target)
    {
        Target = target;
    }
}
