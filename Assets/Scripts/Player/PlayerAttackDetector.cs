using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackDetector : MonoBehaviour
{
    private List<IDamageable> _attackedTargets;

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

    public int GetAmountTargets()
    {
        return _attackedTargets.Count;
    }

    public IDamageable GetHealthManager(int Index)
    {
        return _attackedTargets[Index];
    }
}
