public abstract class EnemyState
{
    public EnemyStateMachine StateMachine { get; private set; }
    public EnemyAnimator Animator { get; private set; }
    public PlayerDetectionDetector PersecutionDetector { get; private set; }

    public EnemyState(EnemyStateMachine stateMachine, EnemyAnimator animator, PlayerDetectionDetector persecutionDetector)
    {
        StateMachine = stateMachine;
        Animator = animator;
        PersecutionDetector = persecutionDetector;
    }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}
