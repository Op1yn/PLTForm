using UnityEngine;

public class PlayerHealthManager : MonoBehaviour, IDamageable
{
    private int _health = 100;

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
}