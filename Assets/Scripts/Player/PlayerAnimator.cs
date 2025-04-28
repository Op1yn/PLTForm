using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundDetector _groundingDetector;
    [SerializeField] private PlayerDamageDealer _damageDealer;

    public static readonly int Speed = Animator.StringToHash(nameof(Speed));
    public static readonly int IsJumping = Animator.StringToHash(nameof(IsJumping));
    public static readonly int IsAttacking = Animator.StringToHash(nameof(IsAttacking));

    private void OnEnable()
    {
        _groundingDetector.LeavingOffGround += SetIsJumpingOffGround;
        _groundingDetector.Landed += SetIsJumpingLanding;
        _damageDealer.AttackBegun += ActivateIsAttacking;
        _damageDealer.AttackOver += DeactivateIsAttacking;
    }

    private void FixedUpdate()
    {
        _animator.SetFloat(Speed, Mathf.Abs(_inputReader.Direction));
    }

    private void OnDisable()
    {
        _groundingDetector.LeavingOffGround -= SetIsJumpingOffGround;
        _groundingDetector.Landed -= SetIsJumpingLanding;
        _damageDealer.AttackBegun -= ActivateIsAttacking;
        _damageDealer.AttackOver -= DeactivateIsAttacking;
    }

    private void SetIsJumpingLanding()
    {
        _animator.SetBool(IsJumping, false);
    }

    private void SetIsJumpingOffGround()
    {
        _animator.SetBool(IsJumping, true);
    }

    private void ActivateIsAttacking()
    {
        //Debug.Log("ActivateIsAttacking");
        _animator.SetBool(IsAttacking, true);
    }

    private void DeactivateIsAttacking()
    {
        //Debug.Log("DeactivateIsAttacking");
        _animator.SetBool(IsAttacking, false);
    }
}
