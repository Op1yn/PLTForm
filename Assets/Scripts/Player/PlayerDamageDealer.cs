using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageDealer : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private EnemiesDetectionDetector _attackDetector;
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
        IReadOnlyList<Enemy> targets = _attackDetector.Targets;

        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i].TryGetComponent<Health>(out Health targetHealth))
                targetHealth.TakeDamage(_damage);
        }
    }
}