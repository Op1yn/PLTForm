using System;
using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private EnemiesDetectionDetector _detector;

    [SerializeField] public float AbilityDuration { get; private set; } = 6;
    [SerializeField] public float CooldownDuration { get; private set; } = 4;

    public event Action VampirismBeganEffect;
    public event Action VampirismWorkingHoursOver;

    private Coroutine _durationTimeCountdown;
    private Coroutine _rechargeTimeCountdown;
    private float _abilityActivationTime;
    private float _extractPerSecond = 10;

    private void OnEnable()
    {
        _inputReader.VampirismButtonPressed += ActivateAbility;
    }

    private void OnDisable()
    {
        _inputReader.VampirismButtonPressed -= ActivateAbility;

        if (_durationTimeCountdown != null)
            StopCoroutine(_durationTimeCountdown);

        if (_rechargeTimeCountdown != null)
            StopCoroutine(_rechargeTimeCountdown);
    }

    private void ActivateAbility()
    {
        if (_durationTimeCountdown == null)
        {
            VampirismBeganEffect?.Invoke();
            _abilityActivationTime = Time.time;
            _durationTimeCountdown = StartCoroutine(CountDownDuration());
        }
    }

    private IEnumerator CountDownDuration()
    {
        while (Time.time < _abilityActivationTime + AbilityDuration)
        {
            ExtractHealthFromEnemyInZoneAction();

            yield return null;
        }

        _rechargeTimeCountdown = StartCoroutine(CountDownRecharge());
    }

    private void ExtractHealthFromEnemyInZoneAction()
    {
        if (_detector.Targets.Count > 0 && _detector.GetNearestEnemy().TryGetComponent<Health>(out Health targetHealth))
            targetHealth.TakeDamage(_extractPerSecond * Time.deltaTime);
    }

    private IEnumerator CountDownRecharge()
    {
        VampirismWorkingHoursOver?.Invoke();

        yield return new WaitForSeconds(CooldownDuration);

        if (_durationTimeCountdown != null)
        {
            //StopCoroutine(_durationTimeCountdown);
            _durationTimeCountdown = null;

            yield break;
        }
    }
}
