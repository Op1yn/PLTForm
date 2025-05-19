using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour, IDamageable
{
    private int _maximumHealth = 200;
    private int _health = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Apple apple;

        if (other.gameObject.TryGetComponent<Apple>(out apple))
        {
            ReplenishHealth(apple.RecoverableHealth);
            apple.gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        if (_health < damage)
        {
            _health = 0;
        }
        else
        {
            _health -= damage;
        }
    }

    public void ReplenishHealth(int value)
    {
        if (_health + value > _maximumHealth)
        {
            _health = _maximumHealth;
        }
        else
        {
            _health += value;
        }
    }
}