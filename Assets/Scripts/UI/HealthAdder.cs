using UnityEngine;
using UnityEngine.UI;

public class HealthAdder : MonoBehaviour
{
    [SerializeField] private int _magnificationValue;
    [SerializeField] private Button _healthAdderButton;
    [SerializeField] private Health _health;

    private void Awake()
    {
        _healthAdderButton.onClick.AddListener(AddHealth);
    }

    private void OnDisable()
    {
        _healthAdderButton.onClick.RemoveListener(AddHealth);
    }

    private void AddHealth()
    {
        _health.ReplenishHealth(_magnificationValue);
    }
}