using System;
using UnityEngine;

public class EnemyPersecutionDetector : MonoBehaviour
{
    public Action<Transform> PlayerDetected;

    private Transform _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _player = collision.gameObject.transform;
            PlayerDetected?.Invoke(player.transform);
        }
    }

    public bool TryGetPlayerTransform(out Transform player)
    {
        bool hasPlayerDetected = false;
        player = null;

        if (_player != null)
        {
            player = _player;
            hasPlayerDetected = true;
        }

        return hasPlayerDetected;
    }
}