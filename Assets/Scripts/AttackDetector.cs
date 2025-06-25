using System;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetector : MonoBehaviour
{
    public event Action AvailableTargetAdded;
    public event Action AvailableTargetRemoved;

    private List<Health> _attackedPlayers;
    private List<Health> _attackedEnemies;

    private void Start()
    {
        _attackedPlayers = new List<Health>();
        _attackedEnemies = new List<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out IDamageable _))
        {
            if (collision.TryGetComponent<Player>(out Player player))
            {
                if (player.TryGetComponent<Health>(out Health health))
                    _attackedPlayers.Add(health);
            }
            else if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            {
                if (enemy.TryGetComponent<Health>(out Health health))
                    _attackedEnemies.Add(health);
            }

            AvailableTargetAdded?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out IDamageable _))
        {
            if (collision.TryGetComponent<Player>(out Player player))
            {
                if (player.TryGetComponent<Health>(out Health health))
                    _attackedPlayers.Remove(health);
            }
            else if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            {
                if (enemy.TryGetComponent<Health>(out Health health))
                    _attackedEnemies.Remove(health);
            }

            AvailableTargetRemoved?.Invoke();
        }
    }

    public List<Health> GetPlayersHealthInAttackZone()
    {
        return new List<Health>(_attackedPlayers);
    }

    public List<Health> GetEnemiesHealthInAttackZone()
    {
        return new List<Health>(_attackedEnemies);
    }
}