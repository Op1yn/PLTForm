using System;
using UnityEngine;

public class PlayerDetectionDetector : MonoBehaviour
{
    public event Action PlayerEnteredAffectedArea;
    public event Action PlayerLeftAffectedArea;

    public Player Player { get; private set; }

    private void Awake()
    {
        Player = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Player = player;
            PlayerEnteredAffectedArea?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Player = null;
            PlayerLeftAffectedArea?.Invoke();
        }
    }
}