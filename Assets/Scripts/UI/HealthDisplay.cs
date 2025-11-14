using UnityEngine;

public abstract class HealthDisplay : MonoBehaviour
{
    [field: SerializeField] public Health Health { get; private set; }

    private void Awake()
    {
        SetMaximumHealthDisplay();
        UpdateHealthDisplay();
    }

    private void OnEnable()
    {
        Health.HealthChanged += UpdateHealthDisplay;
    }

    private void OnDisable()
    {
        Health.HealthChanged -= UpdateHealthDisplay;
    }

    public abstract void SetMaximumHealthDisplay();

    public abstract void UpdateHealthDisplay();
}
