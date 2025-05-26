using UnityEngine;

public class EnemyStateAttack : EnemyState
{
    private float _timeLastStrike = 0;
    private float _delayBetweenAttacks = 2.2f;

    public EnemyStateAttack(EnemyStateMachine stateMachine, Flipper flipper, EnemyPersecutionDetector enemyPersecutionManager, EnemyAnimator enemyAnimator, AttackDetector attackDetector) : base(stateMachine, enemyPersecutionManager, enemyAnimator, attackDetector)
    {
    }

    public override void Enter(Transform T)
    {
        _timeLastStrike = Time.time;
        SetTarget(T);
        Debug.Log(Target);
        EnemyAnimator.StartAttackAnimation();
    }

    public override void Update()
    {
        if (_timeLastStrike + _delayBetweenAttacks < Time.time)
        {
            EnemyAnimator.StopAttackAnimation();
            EnemyStateMachine.ChangeState<EnemyStatePersecution>(Target);
        }
    }
}