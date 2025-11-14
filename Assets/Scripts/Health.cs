using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [field: SerializeField] public int MaximumHealthPoints { get; private set; }
    [field: SerializeField] public int HealthPoints { get; private set; }

    public event Action HealthChanged;

    private int _minimumHealthPoints = 0;

    public void TakeDamage(int damage)
    {
        if (IsNumberPositive(damage))
        {
            if (IsNumberPositive(HealthPoints - damage))
            {
                HealthPoints -= damage;
            }
            else
            {
                HealthPoints = 0;
                gameObject.SetActive(false);
            }

            HealthChanged?.Invoke();
        }
    }

    public void ReplenishHealth(int value)
    {
        if (IsNumberPositive(value))
        {
            HealthPoints = Mathf.Clamp(HealthPoints + value, _minimumHealthPoints, MaximumHealthPoints);
            HealthChanged?.Invoke();
        }
    }

    private bool IsNumberPositive(int value)
    {
        return value > 0;
    }
}
