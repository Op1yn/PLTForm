using UnityEngine;

public class EnemyStateMovement : EnemyState
{
    public EnemyStateMovement(EnemyStateMachine stateMachine, Transform transform, float speed, Flipper flipper, PersecutionDetector persecutionDetector, EnemyAnimator animator, AttackDetector attackDetector) : base(stateMachine, persecutionDetector, animator, attackDetector)
    {
        Transform = transform;
        Flipper = flipper;
        PersecutionDetector = persecutionDetector;
        Speed = speed;
    }

    public Transform Transform { get; private set; }
    public Flipper Flipper { get; private set; }
    public PersecutionDetector PersecutionDetector { get; private set; }
    public Transform TargetToMoveTowards { get; private set; }
    public float Speed { get; private set; }

    public override void Update()
    {
        Flipper.TurnFront(TargetToMoveTowards.position.x - Transform.position.x);
        Move();
    }

    public virtual void Move()
    {
        Transform.position = Vector2.MoveTowards(Transform.position, TargetToMoveTowards.transform.position, Speed * Time.deltaTime);
    }

    public virtual void SetTargetToMoveTowards(Transform targetToMoveTowards)
    {
        TargetToMoveTowards = targetToMoveTowards;
    }
}