using UnityEngine;

public class VampirismZoneDisplay : MonoBehaviour
{
    [SerializeField] private Vampirism _vampirism;
    [SerializeField] private SpriteRenderer _coverageZone;

    private void OnEnable()
    {
        _coverageZone.enabled = false;
        _vampirism.VampirismBeganEffect += TurnOnDisplay;
        _vampirism.VampirismWorkingHoursOver += TurnOffDisplay;
    }

    private void OnDisable()
    {
        _vampirism.VampirismBeganEffect -= TurnOnDisplay;
        _vampirism.VampirismWorkingHoursOver -= TurnOffDisplay;
    }

    private void TurnOnDisplay()
    {
        _coverageZone.enabled = true;
    }

    private void TurnOffDisplay()
    {
        _coverageZone.enabled = false;
    }
}