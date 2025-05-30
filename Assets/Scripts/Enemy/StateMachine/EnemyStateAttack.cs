using UnityEngine;

public class EnemyStateAttack : EnemyState
{
    //—делаю всЄ по другому. Ѕуду тут подписывать методы на событие завершени€ завершени€ анимации атаки.  аждый раз при завершении атаки будут делатьс€ попытки перейти в преследование и в патрулирование.
    //ƒл€ этого во-первых методы должны быть строго взаимоисключающими, а во вторых об€зательно должны быть готовы все булевые дл€ перехода.
    //ƒл€ перехода в преследование игрок должен быть вне зоны атаки, а дл€ перехода в патрулирование игрок ещЄ должен быть и вне зоны видени€. Ёто надо сделать вложенными »‘ами
    private AttackDetector _attackDetector;

    public EnemyStateAttack(EnemyStateMachine stateMachine, Flipper flipper, EnemyPersecutionDetector enemyPersecutionManager, EnemyAnimator enemyAnimator, AttackDetector attackDetector) : base(stateMachine, enemyPersecutionManager, enemyAnimator, attackDetector)
    {
        _attackDetector = attackDetector;
    }

    public override void Enter()
    {
        Debug.Log("јтака");
        EnemyAnimator.SetTrueAttackAnimation();
        _attackDetector.AvailableTargetRemoved += TruSetFalseIsAttackAnimation;
        _attackDetector.AvailableTargetAdded += TruSetTrueAttackAnimation;
        EnemyAnimator.AttackAnimationEnded += TryEnterToPersecutionState;
        EnemyPersecutionDetector.PlayerDisappeared += TruEnterToPatrollingState;
    }

    public override void Exit()
    {
        Debug.Log("1");
        _attackDetector.AvailableTargetRemoved -= TruSetFalseIsAttackAnimation;
        _attackDetector.AvailableTargetAdded -= TruSetTrueAttackAnimation;
        EnemyAnimator.AttackAnimationEnded -= TryEnterToPersecutionState;
        EnemyPersecutionDetector.PlayerDisappeared -= TruEnterToPatrollingState;
    }

    private void TryEnterToPersecutionState()
    {
        Debug.Log("2");
        if (EnemyAnimator.GetIsAttack() == false)
        {
            Debug.Log("22");
            EnemyStateMachine.ChangeState<EnemyStatePersecution>();
        }
    }

    private void TruEnterToPatrollingState()
    {
        Debug.Log($"3 { EnemyAnimator.IsAttackAnimationPlaying}");

        if (EnemyAnimator.IsAttackAnimationPlaying == false)//Ќужно провер€ть не булевую IsAttack, а переходить при условии, что сработало событие завершени€ атаки.  ак вариант в AttackDetector можно сделать булевую котора€ будет true в методе SetTrueAttackAnimation, а false в методе InformAboutCompletionOfAttackAnimation
        {
            Debug.Log("33");
            EnemyStateMachine.ChangeState<EnemyStatePatrolling>();
        }
    }

    private void TruSetTrueAttackAnimation(GameObject gameObject)
    {
        Debug.Log("4");
        if (gameObject.TryGetComponent<Player>(out Player _))
        {
            Debug.Log("44");
            EnemyAnimator.SetTrueAttackAnimation();
        }
    }

    private void TruSetFalseIsAttackAnimation(GameObject gameObject)
    {
        Debug.Log("5");
        if (gameObject.TryGetComponent<Player>(out Player _))
        {
            Debug.Log("55");
            EnemyAnimator.SetFalseAttackAnimation();
        }
    }
}