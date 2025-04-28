using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageDealer : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundDetector _groundDetector;

    private List<IDamageable> _canTakeDamage;
    private bool _isAttacking = false;
    private int _damage = 20;
    private float _delayBetweenAttacks = 0.5f;
    private float _timeLastStrike = 0;

    public event Action AttackBegun;
    public event Action AttackOver;

    private void Start()
    {
        _canTakeDamage = new List<IDamageable>();
    }

    private void OnEnable()
    {
        _inputReader.AttackButtonBeenPressed += DealDamage;
    }

    private void Update()
    {
        if (_timeLastStrike + _delayBetweenAttacks < Time.time)
        {
            _isAttacking = false;
            AttackOver?.Invoke();
        }
    }

    private void OnDisable()
    {
        _inputReader.AttackButtonBeenPressed -= DealDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            _canTakeDamage.Add(damageable);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
            _canTakeDamage.Remove(damageable);
    }

    private void DealDamage()
    {
        if (_isAttacking == false)
        {
            _isAttacking = true;

            if (_groundDetector.IsGround)
            {
                AttackBegun?.Invoke();

                for (int i = _canTakeDamage.Count - 1; i >= 0; i--)
                {
                    _canTakeDamage[i].TakeDamage(_damage);
                }
            }

            _timeLastStrike = Time.time;
        }
    }
}