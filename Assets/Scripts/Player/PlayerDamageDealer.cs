using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageDealer : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private PlayerDetector _attackDetector;
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
        IReadOnlyList<Health> targets = _attackDetector.Targets;

        for (int i = 0; i < targets.Count; i++)
        {
            targets[i].TakeDamage(_damage);
        }
    }
}