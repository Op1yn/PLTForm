public class EnemyStateMovement<T> : EnemyState where T : IMoving
{
    public T Mover { get; private set; }
    public Flipper Flipper { get; private set; }

    public EnemyStateMovement(EnemyStateMachine stateMachine, EnemyAnimator animator, PlayerDetectionDetector persecutionDetector, T mover, Flipper flipper) : base(stateMachine, animator, persecutionDetector)
    {
        Mover = mover;
        Flipper = flipper;
    }

    public override void Update()
    {
        Mover.Move();
    }
}