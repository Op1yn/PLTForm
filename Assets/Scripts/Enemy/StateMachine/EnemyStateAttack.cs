using UnityEngine;

public class EnemyStateAttack : EnemyState
{
    private int _damage = 25;
    private float _timeLastStrike = 0;
    private float _delayBetweenAttacks = 2.2f;

    public EnemyStateAttack(EnemyStateMachine stateMachine, Flipper flipper, EnemyPersecutionDetector enemyPersecutionManager, EnemyAttackDetector enemyAttackDetector, EnemyAnimator enemyAnimator) : base(stateMachine, enemyPersecutionManager, enemyAttackDetector, enemyAnimator)
    {
        EnemyAnimator.StruckWith += TryInflictDamage;
    }

    public override void Enter(Transform T)
    {
        _timeLastStrike = Time.time;
        SetTarget(T);
        EnemyAnimator.StartAttackAnimation();
    }

    public override void Update()
    {
        if (_timeLastStrike + _delayBetweenAttacks < Time.time)
        {
            EnemyAnimator.StopAttackAnimation();
            EnemyStateMachine.SetState<EnemyStatePersecution>(Target);
        }
    }

    private void TryInflictDamage()
    {
        if (EnemyAttackDetector.TryGetPlayerHealthManager(out Health health))
        {
            health.TakeDamage(_damage);
        }
    }
}