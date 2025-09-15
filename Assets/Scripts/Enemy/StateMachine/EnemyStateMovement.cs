using UnityEngine;

public class EnemyStateMovement : EnemyState
{
    public EnemyStateMovement(EnemyStateMachine stateMachine, Transform transform, Flipper flipper, EnemyDetector persecutionDetector, EnemyAnimator animator, EnemyDetector attackDetector, EnemyMover enemyMover) : base(stateMachine, persecutionDetector, animator, attackDetector)
    {
        EnemyMover = enemyMover;
        Transform = transform;
        Flipper = flipper;
        PersecutionDetector = persecutionDetector;
    }

    public EnemyMover EnemyMover { get; private set; }
    public Transform Transform { get; private set; }
    public Flipper Flipper { get; private set; }
    public EnemyDetector PersecutionDetector { get; private set; }
    public float Speed { get; private set; }

    public override void Enter()
    {
    }

    public override void Update()
    {
        Flipper.TurnFront(EnemyMover.TargetToMoveTowards.position.x - Transform.position.x);
        EnemyMover.Move();
    }
}