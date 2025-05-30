using UnityEngine;

public class EnemyStatePersecution : EnemyStateMovement
{
    private float _distanceCeasePersecution = 1.2f;
    private AttackDetector _attackDetector;

    public EnemyStatePersecution(EnemyStateMachine stateMachine, Transform transform, float speed, Flipper flipper, EnemyPersecutionDetector enemyPersecutionManager, EnemyAnimator enemyAnimator, AttackDetector attackDetector) : base(stateMachine, transform, speed, flipper, enemyPersecutionManager, enemyAnimator, attackDetector)
    {
        _attackDetector = attackDetector;
    }

    public override void Enter()
    {
        Debug.Log($"Преследование");
        //if (EnemyPersecutionDetector.Player == null)
        //{
        //    EnterStateOfPatrolling();
        //    //return;
        //}

        SetTarget(EnemyPersecutionDetector.Player);

        EnemyPersecutionDetector.PlayerDisappeared += EnterStateOfPatrolling;
        _attackDetector.AvailableTargetAdded += TryEnterStateOfAttack;
    }

    public override void Update()
    {
        if (Mathf.Abs(Target.transform.position.x - Transform.position.x) > _distanceCeasePersecution)
            Transform.position = Vector2.MoveTowards(Transform.position, new Vector2(Target.transform.position.x, Transform.position.y), Speed * Time.deltaTime);

        Flipper.TurnFront(Target.position.x - Transform.position.x);
    }

    public override void Exit()
    {
        EnemyPersecutionDetector.PlayerDisappeared -= EnterStateOfPatrolling;
        _attackDetector.AvailableTargetAdded -= TryEnterStateOfAttack;
    }

    private void EnterStateOfPatrolling()
    {
        EnemyStateMachine.ChangeState<EnemyStatePatrolling>();
    }

    private void TryEnterStateOfAttack(GameObject gameObject)
    {
        if (gameObject.TryGetComponent<Player>(out Player _))
        {
            EnemyStateMachine.ChangeState<EnemyStateAttack>();
        }
    }
}