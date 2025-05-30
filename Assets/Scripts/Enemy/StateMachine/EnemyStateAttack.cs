using UnityEngine;

public class EnemyStateAttack : EnemyState
{
    //������ �� �� �������. ���� ��� ����������� ������ �� ������� ���������� ���������� �������� �����. ������ ��� ��� ���������� ����� ����� �������� ������� ������� � ������������� � � ��������������.
    //��� ����� ��-������ ������ ������ ���� ������ ������������������, � �� ������ ����������� ������ ���� ������ ��� ������� ��� ��������.
    //��� �������� � ������������� ����� ������ ���� ��� ���� �����, � ��� �������� � �������������� ����� ��� ������ ���� � ��� ���� �������. ��� ���� ������� ���������� �����
    private AttackDetector _attackDetector;

    public EnemyStateAttack(EnemyStateMachine stateMachine, Flipper flipper, EnemyPersecutionDetector enemyPersecutionManager, EnemyAnimator enemyAnimator, AttackDetector attackDetector) : base(stateMachine, enemyPersecutionManager, enemyAnimator, attackDetector)
    {
        _attackDetector = attackDetector;
    }

    public override void Enter()
    {
        Debug.Log("�����");
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

        if (EnemyAnimator.IsAttackAnimationPlaying == false)//����� ��������� �� ������� IsAttack, � ���������� ��� �������, ��� ��������� ������� ���������� �����. ��� ������� � AttackDetector ����� ������� ������� ������� ����� true � ������ SetTrueAttackAnimation, � false � ������ InformAboutCompletionOfAttackAnimation
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