using System;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public event Action CompletedStrike;
    public event Action AttackAnimationEnded;

    public static readonly int IsAttack = Animator.StringToHash(nameof(IsAttack));

    public void ReportAttack()
    {
        CompletedStrike?.Invoke();
    }

    public void SetTrueAttackAnimation()
    {
        _animator.SetBool(IsAttack, true);
    }

    public void SetFalseAttackAnimation()
    {
        _animator.SetBool(IsAttack, false);
    }

    public void InformAboutCompletionOfAttackAnimation()
    {
        AttackAnimationEnded?.Invoke();
    }
}