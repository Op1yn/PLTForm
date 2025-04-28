using System;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public static readonly int IsAttack = Animator.StringToHash(nameof(IsAttack));
    public event Action StruckWith;
   
    public void ReportAttack()
    {
        StruckWith?.Invoke();
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