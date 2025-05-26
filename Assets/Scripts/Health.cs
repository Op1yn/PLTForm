using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maximumHealthPoints;
    [SerializeField] private int _healthPoints;

    public void TakeDamage(int damage)
    {
        if (_healthPoints - damage > 0)
        {
            _healthPoints -= damage;
        }
        else
        {
            _healthPoints = 0;
            gameObject.SetActive(false);
        }
    }

    public void ReplenishHealth(int value)
    {
        if (_healthPoints + value > _maximumHealthPoints)
        {
            _healthPoints = _maximumHealthPoints;
        }
        else
        {
            _healthPoints += value;
        }
    }
}
