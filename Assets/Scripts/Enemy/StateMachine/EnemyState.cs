public abstract class EnemyState
{
    public EnemyStateMachine StateMachine { get; private set; }
    public EnemyAnimator Animator { get; private set; }

    public EnemyState(EnemyStateMachine stateMachine, EnemyDetector enemyPersecutionDetector, EnemyAnimator enemyAnimator, EnemyDetector attackDetector)
    {
        StateMachine = stateMachine;
        Animator = enemyAnimator;
    }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}
