using System;
using UnityEngine;

public class EnemyAttackDetector : MonoBehaviour
{
    public bool IsPlayerInAttackZone { get; private set; }
    public PlayerHealthManager PlayerHealthManager { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealthManager>(out PlayerHealthManager playerHealthManager))
        {
            PlayerHealthManager = playerHealthManager;
            IsPlayerInAttackZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealthManager>(out _))
        {
            PlayerHealthManager = null;
            IsPlayerInAttackZone = false;
        }
    }

    public bool TryGetPlayerHealthManager(out PlayerHealthManager playerHealthManager)
    {
        bool hasPlayerDetected = false;
        playerHealthManager = null;

        if (PlayerHealthManager != null)
        {
            playerHealthManager = PlayerHealthManager;
            hasPlayerDetected = true;
        }

        return hasPlayerDetected;
    }
}