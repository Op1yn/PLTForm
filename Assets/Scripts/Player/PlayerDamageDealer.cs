using System;
using UnityEngine;

public class PlayerDamageDealer : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private PlayerAttackDetector _attackDetector;
    [SerializeField] private int _damage = 20;

    public event Action AttackBegun;
    public event Action AttackOver;

    private void Start()
    {
        _animator.StruckWith += TryInflictDamage;
    }

    private void TryInflictDamage()
    {
        for (int i = 0; i < _attackDetector.CanTakeDamage.Count; i++)
        {
            _attackDetector.GetHealthManager(i).TakeDamage(_damage);
        }
    }
}