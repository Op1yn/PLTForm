using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public static readonly int Speed = Animator.StringToHash(nameof(Speed));
    public static readonly int IsAttacking = Animator.StringToHash(nameof(IsAttacking));
    public static readonly int Jumping = Animator.StringToHash(nameof(Jumping));
    public static readonly int Graunded = Animator.StringToHash(nameof(Graunded));

    public event Action CompletedStrike;

    public void SetSpeed(float speed)
    {
        _animator.SetFloat(Speed, Mathf.Abs(speed));
    }

    public void Jump()
    {
        _animator.SetBool(Jumping, true);
    }

    public void StopJump()
    {
        _animator.SetBool(Graunded, true);
    }

    public void StartAttack()
    {
        _animator.SetBool(IsAttacking, true);
    }

    public void StopAttack()
    {
        _animator.SetBool(IsAttacking, false);
    }

    public void ReportAttack()
    {
        CompletedStrike?.Invoke();
    }
}
