using System.Collections;
using UnityEngine;

public class SmoothHealthBarDisplay : HealthBarDisplay
{
    [SerializeField] private float _speedSmoothness;

    private Coroutine _smoothChangeHealthDisplay;

    public override void UpdateHealthDisplay()
    {
        if (_smoothChangeHealthDisplay != null)
            StopCoroutine(_smoothChangeHealthDisplay);

        _smoothChangeHealthDisplay = StartCoroutine(SmootUpdateHealthDisplay());
    }

    private IEnumerator SmootUpdateHealthDisplay()
    {
        while (AvailableAmountHealthBar.value != Health.HealthPoints)
        {
            AvailableAmountHealthBar.value = Mathf.MoveTowards(AvailableAmountHealthBar.value, Health.HealthPoints, _speedSmoothness * Time.deltaTime);

            yield return null;
        }
    }
}