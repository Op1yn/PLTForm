public class EnemyDamageDealer
{
    private int _damage;
    private PlayerDetectionDetector _attackDetector;

    public EnemyDamageDealer(PlayerDetectionDetector attackDetector, int damage)
    {
        _attackDetector = attackDetector;
        _damage = damage;
    }

    public void TryDamagePlayer()
    {
        if (_attackDetector.Player != null && _attackDetector.Player.TryGetComponent<Health>(out Health health))
            health.TakeDamage(_damage);
    }
}
