using System;
using UnityEngine;

public class EnemyPersecutionDetector : MonoBehaviour
{
    public event Action PlayerDetected;
    public event Action PlayerDisappeared;

    public Transform Player { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            Player = collision.gameObject.transform;
            PlayerDetected?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            PlayerDisappeared?.Invoke();
            Player = null;
        }
    }
}