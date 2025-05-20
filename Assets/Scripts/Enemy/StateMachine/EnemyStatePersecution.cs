using UnityEngine;

public class EnemyStatePersecution : EnemyStateMovement
{
    private float _distanceCeasePersecution = 1.2f;
    private float _delayBetweenAttacks = 2.2f;
    private float _timeLastStrike = 0;

    public EnemyStatePersecution(EnemyStateMachine stateMachine, Transform transform, float speed, Flipper flipper, EnemyPersecutionDetector enemyPersecutionManager, EnemyAttackDetector enemyAttackDetector, EnemyAnimator enemyAnimator) : base(stateMachine, transform, speed, flipper, enemyPersecutionManager, enemyAttackDetector, enemyAnimator)
    {
        EnemyAttackDetector = enemyAttackDetector;
    }

    public override void Enter(Transform T)
    {
        SetTarget(T);
    }

    public override void Update()
    {
        if (Mathf.Abs(Target.transform.position.x - Transform.position.x) > _distanceCeasePersecution)
            Transform.position = Vector2.MoveTowards(Transform.position, new Vector2(Target.transform.position.x, Transform.position.y), Speed * Time.deltaTime);

        if (EnemyAttackDetector.TryGetPlayerHealthManager(out Health health))
        {
            if (_timeLastStrike + _delayBetweenAttacks < Time.time)
            {
                _timeLastStrike = Time.time;
                EnemyStateMachine.SetState<EnemyStateAttack>(health.transform);
            }
        }

        Flipper.TurnFront(Target.position.x - Transform.position.x);
    }
}