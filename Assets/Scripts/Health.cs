using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maximumHealthPoints;
    [SerializeField] private int _healthPoints;

    private int _minimumHealthPoints = 0;

    public void TakeDamage(int damage)
    {
        if (IsNumberPositive(damage))
        {
            if (IsNumberPositive(_healthPoints - damage))
            {
                _healthPoints -= damage;
            }
            else
            {
                _healthPoints = 0;
                gameObject.SetActive(false);
            }
        }
    }

    public void ReplenishHealth(int value)
    {
        if (IsNumberPositive(value))
            _healthPoints = Mathf.Clamp(_healthPoints + value, _minimumHealthPoints, _maximumHealthPoints);
    }

    private bool IsNumberPositive(int value)
    {
        return value > 0;
    }
}
