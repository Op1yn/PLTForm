using UnityEngine;
using UnityEngine.UI;

public class HealthReducer : MonoBehaviour
{
    [SerializeField] private int _reductionValue;
    [SerializeField] private Button _healthReductionButton;
    [SerializeField] private Health _health;

    private void Awake()
    {
        _healthReductionButton.onClick.AddListener(ReduceHealth);
    }

    private void OnDisable()
    {
        _healthReductionButton.onClick.RemoveListener(ReduceHealth);
    }

    private void ReduceHealth()
    {
        _health.TakeDamage(_reductionValue);
    }
}