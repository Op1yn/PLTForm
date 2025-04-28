using UnityEngine;

public class EnemyStateAttack : EnemyState
{
    //В аниматоре нужно сделать систему как описано тут https://t.me/KaDR_gamedev/176

    private int _damage = 25;
    private float _timeLastStrike = 0;
    private float _delayBetweenAttacks = 2.2f;

    public EnemyStateAttack(EnemyStateMachine stateMachine, EnemyFlipper enemyFlipper, EnemyPersecutionDetector enemyPersecutionManager, EnemyAttackDetector enemyAttackDetector, EnemyAnimator enemyAnimator) : base(stateMachine, enemyFlipper, enemyPersecutionManager, enemyAttackDetector, enemyAnimator)
    {
        _enemyAnimator.StruckWith += TryInflictDamage;
    }

    public override void Enter(Transform T)
    {
        _timeLastStrike = Time.time;
        SetTarget(T);
        _enemyAnimator.StartAttackAnimation();
    }

    public override void Update()
    {
        if (_timeLastStrike + _delayBetweenAttacks < Time.time)
        {
            _enemyAnimator.StopAttackAnimation();
            _enemyStateMachine.SetState<EnemyStatePersecution>(Target);
        }
    }

    public override void Exit()
    {
        Debug.Log("Вышел из Атаки");
    }

    private void TryInflictDamage()
    {
        if (_enemyAttackDetector.TryGetPlayerHealthManager(out PlayerHealthManager playerHealthManager))
        {
            playerHealthManager.TakeDamage(_damage);
        }
    }
}