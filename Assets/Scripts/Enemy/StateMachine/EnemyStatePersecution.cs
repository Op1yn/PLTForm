using UnityEngine;

public class EnemyStatePersecution : EnemyStateMovement
{
    private float _distanceCeasePersecution = 1.2f;
    private AttackDetector _attackDetector;

    public EnemyStatePersecution(EnemyStateMachine stateMachine, Transform transform, float speed, Flipper flipper, EnemyPersecutionDetector enemyPersecutionManager, EnemyAnimator enemyAnimator, AttackDetector attackDetector) : base(stateMachine, transform, speed, flipper, enemyPersecutionManager, enemyAnimator, attackDetector)
    {
        _attackDetector = attackDetector;
    }

    public override void Enter(Transform T)
    {
        Debug.Log("����������");
        SetTarget(T);
    }

    public override void Update()
    {
        if (Mathf.Abs(Target.transform.position.x - Transform.position.x) > _distanceCeasePersecution)
            Transform.position = Vector2.MoveTowards(Transform.position, new Vector2(Target.transform.position.x, Transform.position.y), Speed * Time.deltaTime);

        if (_attackDetector.CountTargets > 0)
        {
            EnemyStateMachine.ChangeState<EnemyStateAttack>(Target);
        }

        Flipper.TurnFront(Target.position.x - Transform.position.x);
    }
}