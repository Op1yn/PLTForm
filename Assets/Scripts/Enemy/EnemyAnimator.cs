using System;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public event Action CompletedStrike;

    public static readonly int IsAttack = Animator.StringToHash(nameof(IsAttack));
   
    public void ReportAttack()
    {
        CompletedStrike?.Invoke();
    }

    public void StartAttackAnimation()
    {
        _animator.SetBool(IsAttack, true);
    }

    public void StopAttackAnimation()
    {
        _animator.SetBool(IsAttack, false);
    }
}