using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [field: SerializeField] public float MaximumHealthPoints { get; private set; }
    [field: SerializeField] public float HealthPoints { get; private set; }

    public event Action HealthChanged;

    private float _minimumHealthPoints = 0;

    public void TakeDamage(float damage)
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

    public void ReplenishHealth(float value)
    {
        if (IsNumberPositive(value))
        {
            HealthPoints = Mathf.Clamp(HealthPoints + value, _minimumHealthPoints, MaximumHealthPoints);
            HealthChanged?.Invoke();
        }
    }

    private bool IsNumberPositive(float value)
    {
        return value > 0;
    }
}
