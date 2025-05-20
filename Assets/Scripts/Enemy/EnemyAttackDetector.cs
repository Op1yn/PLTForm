using UnityEngine;

public class EnemyAttackDetector : MonoBehaviour
{
    private Health _health;

    public bool IsPlayerInAttackZone { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            _health = health;
            IsPlayerInAttackZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out _))
        {
            _health = null;
            IsPlayerInAttackZone = false;
        }
    }

    public bool TryGetPlayerHealthManager(out Health health)
    {
        bool hasPlayerDetected = false;
        health = null;

        if (_health != null)
        {
            health = _health;
            hasPlayerDetected = true;
        }

        return hasPlayerDetected;
    }
}