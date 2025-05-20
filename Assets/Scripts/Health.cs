using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maximumHealth;
    [SerializeField] private int _health;

    public void TakeDamage(int damage)
    {
        if (_health - damage > 0)
        {
            _health -= damage;
        }
        else
        {
            gameObject.SetActive(false);
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
