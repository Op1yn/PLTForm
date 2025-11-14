using UnityEngine;
using UnityEngine.UI;

public class TextHealthDisplay : HealthDisplay
{
    [SerializeField] private Text _healthText;

    private string _currentValueHealthInText;
    private string _maximumHealthValueInText;

    public override void SetMaximumHealthDisplay()
    {
        _maximumHealthValueInText = Health.MaximumHealthPoints.ToString();
    }

    public override void UpdateHealthDisplay()
    {
        _currentValueHealthInText = Health.HealthPoints.ToString();

        _healthText.text = $"{_currentValueHealthInText}/{_maximumHealthValueInText}";
    }
}
