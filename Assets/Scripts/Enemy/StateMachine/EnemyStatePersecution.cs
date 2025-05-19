using UnityEngine;

public class EnemyStatePersecution : EnemyStateMovement
{
    private float _distanceCeasePersecution = 1.2f;
    private float _delayBetweenAttacks = 2.2f;
    private float _timeLastStrike = 0;

    public EnemyStatePersecution(EnemyStateMachine stateMachine, Transform transform, float speed, EnemyFlipper enemyFlipper, EnemyPersecutionDetector enemyPersecutionManager, EnemyAttackDetector enemyAttackDetector, EnemyAnimator enemyAnimator) : base(stateMachine, transform, speed, enemyFlipper, enemyPersecutionManager, enemyAttackDetector, enemyAnimator)
    {
        _enemyAttackDetector = enemyAttackDetector;
    }

    public override void Enter(Transform T)
    {
        SetTarget(T);
    }

    public override void Update()
    {
        if (Mathf.Abs(Target.transform.position.x - _transform.position.x) > _distanceCeasePersecution)
            _transform.position = Vector2.MoveTowards(_transform.position, new Vector2(Target.transform.position.x, _transform.position.y), _speed * Time.deltaTime);

        if (_enemyAttackDetector.TryGetPlayerHealthManager(out PlayerHealthManager playerHealthManager))
        {
            if (_timeLastStrike + _delayBetweenAttacks < Time.time)
            {
                _timeLastStrike = Time.time;
                _enemyStateMachine.SetState<EnemyStateAttack>(playerHealthManager.transform);
            }
        }
    }
}