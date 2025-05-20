using UnityEngine;

public class PlayerDamageDealer : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private PlayerAttackDetector _attackDetector;
    [SerializeField] private int _damage = 20;

    private void OnEnable()
    {
        _animator.CompletedStrike += TryInflictDamage;
    }

    private void OnDisable()
    {
        _animator.CompletedStrike -= TryInflictDamage;
    }

    private void TryInflictDamage()
    {
        for (int i = 0; i < _attackDetector.GetAmountTargets(); i++)
        {
            _attackDetector.GetHealthManager(i).TakeDamage(_damage);
        }
    }
}