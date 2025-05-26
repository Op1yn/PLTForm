using System.Collections.Generic;
using UnityEngine;

public class AttackDetector : MonoBehaviour
{
    private List<IDamageable> _attackedTargets;

    public int CountTargets => _attackedTargets.Count;

    private void Start()
    {
        _attackedTargets = new List<IDamageable>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            _attackedTargets.Add(damageable);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
            _attackedTargets.Remove(damageable);
    }

    public List<IDamageable> GetAttackedTargets()
    {
        return new List<IDamageable>(_attackedTargets);
    }
}