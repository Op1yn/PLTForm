using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{
    [SerializeField] private AttackDetector _attackDetector;
    [SerializeField] private int _damage = 20;

    public void DealDamageToTargets(List<IDamageable> targets)
    {
        for (int i = 0; i < targets.Count; i++)
        {
            targets[i].TakeDamage(_damage);
        }
    }
}
