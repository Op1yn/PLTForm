public abstract class EnemyState
{
    public EnemyStateMachine StateMachine { get; private set; }
    public EnemyAnimator Animator { get; private set; }

    public EnemyState(EnemyStateMachine stateMachine, PersecutionDetector enemyPersecutionDetector, EnemyAnimator enemyAnimator, AttackDetector attackDetector)
    {
        StateMachine = stateMachine;
        Animator = enemyAnimator;
    }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}
