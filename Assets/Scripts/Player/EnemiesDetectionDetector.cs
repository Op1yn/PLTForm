using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemiesDetectionDetector : MonoBehaviour
{
    private List<Enemy> _targets;
    public IReadOnlyList<Enemy> Targets => _targets;

    public Enemy GetNearestEnemy()
    {
        return _targets.OrderBy(enemy => (transform.position - enemy.transform.position).sqrMagnitude).First();
    }

    private void Awake()
    {
        _targets = new List<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy target))
            _targets.Add(target);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy target))
            _targets.Remove(target);
    }
}