using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{

    [SerializeField] private EnemyAnimator _animator;
    [SerializeField] private AttackDetector _attackDetector;
    [SerializeField] private int _damage = 20;

    private void OnEnable()
    {
        _animator.CompletedStrike += TryInflictDamageTargets;
    }

    private void OnDisable()
    {
        _animator.CompletedStrike -= TryInflictDamageTargets;
    }

    private void TryInflictDamageTargets()
    {
        List<IDamageable> targets = _attackDetector.GetAttackedTargets();

        for (int i = 0; i < targets.Count; i++)
        {
            targets[i].TakeDamage(_damage);
        }
    }
}
