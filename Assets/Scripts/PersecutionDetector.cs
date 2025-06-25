using System;
using System.Collections.Generic;
using UnityEngine;

public class PersecutionDetector : MonoBehaviour
{
    public event Action TargetDetected;
    public event Action TargetDisappeared;

    private List<IDamageable> _targetPersecution;
    private List<Player> _playersPersecution;
    private List<Enemy> _enemiesPersecution;

    private void Awake()
    {
        _targetPersecution = new List<IDamageable>();
        _playersPersecution = new List<Player>();
        _enemiesPersecution = new List<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out IDamageable target))
        {
            _targetPersecution.Add(target);

            if (collision.TryGetComponent<Player>(out Player player))
            {
                _playersPersecution.Add(player);
            }
            else if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            {
                _enemiesPersecution.Add(enemy);
            }

            TargetDetected?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out IDamageable target))
        {
            _targetPersecution.Remove(target);

            if (collision.TryGetComponent<Player>(out Player player))
            {
                _playersPersecution.Remove(player);
            }
            else if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            {
                _enemiesPersecution.Remove(enemy);
            }

            TargetDisappeared?.Invoke();
        }
    }

    public List<IDamageable> GetTargetsInPersecutionZone()
    {
        return new List<IDamageable>(_targetPersecution);
    }

    public List<Player> GetPlayersInPersecutionZone()
    {
        return new List<Player>(_playersPersecution);
    }

    public List<Enemy> GetEnemiesInPersecutionZone()
    {
        return new List<Enemy>(_enemiesPersecution);
    }
}