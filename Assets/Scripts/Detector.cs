using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Detector<T> : MonoBehaviour where T : MonoBehaviour
{
    private List<T> _targets;

    public event Action AvailableTargetAdded;
    public event Action AvailableTargetRemoved;

    public IReadOnlyList<T> Targets => _targets;

    //public Detector()
    //{
    //    _targets = new List<T>();
    //}

    private void Awake()
    {
        _targets = new List<T>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<T>(out T target))
            _targets.Add(target);

        AvailableTargetAdded?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<T>(out T target))
            _targets.Remove(target);

        AvailableTargetRemoved?.Invoke();
    }

    public T GetNearestTarget()
    {
        List<T> targetsOrderedByDistance = new List<T>(_targets.OrderBy(p => Mathf.Abs(p.transform.position.x - transform.position.x)));

        return targetsOrderedByDistance[0];
    }
}
