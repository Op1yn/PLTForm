using System;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetector : MonoBehaviour
{
    public Action<GameObject> AvailableTargetAdded;
    public Action<GameObject> AvailableTargetRemoved;

    private List<IDamageable> _attackedTargets;

    private void Awake()
    {
        _attackedTargets = new List<IDamageable>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            _attackedTargets.Add(damageable);
            AvailableTargetAdded?.Invoke(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            _attackedTargets.Remove(damageable);
            AvailableTargetRemoved?.Invoke(collision.gameObject);
        }
    }

    public List<IDamageable> GetAttackedTargets()
    {
        return new List<IDamageable>(_attackedTargets);
    }
}