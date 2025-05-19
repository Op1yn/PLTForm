using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GroundDetector _groundingDetector;
    [SerializeField] private PlayerDamageDealer _damageDealer;

    public event Action StruckWith;

    public static readonly int Speed = Animator.StringToHash(nameof(Speed));
    public static readonly int IsJumping = Animator.StringToHash(nameof(IsJumping));
    public static readonly int IsAttacking = Animator.StringToHash(nameof(IsAttacking));

    public void SetSpeed(float speed)
    {
        _animator.SetFloat(Speed, Mathf.Abs(speed));
    }

    public void SetIsJumpingFalse()
    {
        _animator.SetBool(IsJumping, false);
    }

    public void SetIsJumpingTrue()
    {
        _animator.SetBool(IsJumping, true);
    }

    public void StartAttackAnimation()
    {
        _animator.SetBool(IsAttacking, true);
    }

    public void StopAttackAnimation()
    {
        _animator.SetBool(IsAttacking, false);
    }

    public void ReportAttack()
    {
        StruckWith?.Invoke();
    }
}
