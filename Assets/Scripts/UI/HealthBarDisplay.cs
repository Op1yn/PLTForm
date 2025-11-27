using UnityEngine;
using UnityEngine.UI;

public class HealthBarDisplay : StatDisplay
{
    [field: SerializeField] public Health Health { get; private set; }
    [field: SerializeField] public Slider AvailableAmountHealthBar { get; private set; }

    private void OnEnable()
    {
        Health.HealthPointsChanged += UpdateHealthDisplay;
    }

    private void OnDisable()
    {
        Health.HealthPointsChanged -= UpdateHealthDisplay;
    }

    public override void SetMaximumStatDisplay()
    {
        AvailableAmountHealthBar.maxValue = Health.MaximumHealthPoints;
    }

    public override void UpdateHealthDisplay()
    {
        AvailableAmountHealthBar.value = Health.HealthPoints;
    }
}