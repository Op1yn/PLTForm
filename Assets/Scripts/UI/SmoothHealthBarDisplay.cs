using UnityEngine;

public class SmoothHealthBarDisplay : InstantHealthBarDisplay
{
    [SerializeField] private float _speedSmoothness;

    private void Update()
    {
        AvailableAmountHealthBar.value = Mathf.MoveTowards(AvailableAmountHealthBar.value, Health.HealthPoints, _speedSmoothness * Time.deltaTime);
    }

    public override void UpdateHealthDisplay() { }
}