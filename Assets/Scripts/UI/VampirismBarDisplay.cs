using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VampirismBarDisplay : MonoBehaviour
{
    [SerializeField] private Vampirism _vampirism;
    [SerializeField] private Slider _durationBar;

    private Coroutine _displayingRemainingTimeAction;
    private Coroutine _displayingRechargeTimer;

    private void OnEnable()
    {
        _vampirism.VampirismBeganEffect += StartDisplayingRemainingDurationAbility;
        _vampirism.VampirismWorkingHoursOver += StartDisplayingCountdownToRecharge;
    }

    private void OnDisable()
    {
        _vampirism.VampirismBeganEffect -= StartDisplayingRemainingDurationAbility;
        _vampirism.VampirismWorkingHoursOver -= StartDisplayingCountdownToRecharge;

        if (_displayingRemainingTimeAction != null)
            StopCoroutine(_displayingRemainingTimeAction);

        if (_displayingRechargeTimer != null)
            StopCoroutine(_displayingRechargeTimer);
    }

    private IEnumerator DisplayRemainingTimeAction()
    {
        float remainingTime = _vampirism.AbilityDuration;

        while (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            _durationBar.value = remainingTime / _vampirism.AbilityDuration;

            yield return null;
        }
    }

    private void StartDisplayingRemainingDurationAbility()
    {
        _displayingRemainingTimeAction = StartCoroutine(DisplayRemainingTimeAction());
    }

    private IEnumerator DisplayTimeToRecharge()
    {
        float elapsedTime = 0;

        while (elapsedTime <= _vampirism.CooldownDuration)
        {
            elapsedTime += Time.deltaTime;
            _durationBar.value = elapsedTime / _vampirism.CooldownDuration;

            yield return null;
        }
    }

    private void StartDisplayingCountdownToRecharge()
    {
        _displayingRechargeTimer = StartCoroutine(DisplayTimeToRecharge());
    }
}