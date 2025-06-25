using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageDealer : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private AttackDetector _attackDetector;
    [SerializeField] private int _damage = 20;

    private void OnEnable()
    {
        _animator.CompletedStrike += TryInflictDamageEnemies;
    }

    private void OnDisable()
    {
        _animator.CompletedStrike -= TryInflictDamageEnemies;
    }

    private void TryInflictDamageEnemies()
    {
        List<Health> targets = _attackDetector.GetEnemiesHealthInAttackZone();

        for (int i = 0; i < targets.Count; i++)
        {
            targets[i].TakeDamage(_damage);
        }
    }
}