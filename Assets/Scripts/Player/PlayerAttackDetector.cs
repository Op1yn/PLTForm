using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackDetector : MonoBehaviour
{
    public List<IDamageable> CanTakeDamage { get; private set; }

    private void Start()
    {
        CanTakeDamage = new List<IDamageable>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            CanTakeDamage.Add(damageable);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
            CanTakeDamage.Remove(damageable);
    }

    public IDamageable GetHealthManager(int Index)
    {
        return CanTakeDamage[Index];
    }
}
