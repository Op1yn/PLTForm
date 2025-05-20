using UnityEngine;

public class EnemyStateMovement : EnemyState
{
    public float Speed { get; private set; }
    public Transform Transform { get; private set; }
    public Flipper Flipper { get; private set; }

    public EnemyStateMovement(EnemyStateMachine stateMachine, Transform transform, float speed, Flipper flipper, EnemyPersecutionDetector enemyPersecutionManager, EnemyAttackDetector enemyAttackDetector, EnemyAnimator enemyAnimator) : base(stateMachine, enemyPersecutionManager, enemyAttackDetector, enemyAnimator)
    {
        Transform = transform;
        Flipper = flipper;
        Speed = speed;
    }

    public override void Update()
    {
        Move();
        Flipper.TurnFront(Target.position.x - Transform.position.x);
    }

    public virtual void Move()
    {
        Transform.position = Vector2.MoveTowards(Transform.position, Target.transform.position, Speed * Time.deltaTime);
    }
}