using UnityEngine;

public class EnemyHealthManager : MonoBehaviour, IDamageable
{
    private int _health = 100;

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
}
