using UnityEngine;
using UnityEngine.UI;

public class InstantHealthBarDisplay : HealthDisplay
{
    [field: SerializeField] public Slider AvailableAmountHealthBar { get; private set; }

    public override void SetMaximumHealthDisplay()
    {
        AvailableAmountHealthBar.maxValue = Health.MaximumHealthPoints;
    }

    public override void UpdateHealthDisplay()
    {
        AvailableAmountHealthBar.value = Health.HealthPoints;
    }
}
