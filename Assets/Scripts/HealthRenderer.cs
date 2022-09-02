using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthRenderer : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Coroutine _sliderChangeCoroutine;
    private Slider _healthBar;
    private float _speed = 0.001f;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _health.HealthChanged += StartSliderChanging;
    }

    public void StartSliderChanging()
    {
        if(_sliderChangeCoroutine != null)
        {
            StopCoroutine(_sliderChangeCoroutine);
        }

        _sliderChangeCoroutine = StartCoroutine(ChangeSliderValue());
    }

    private IEnumerator ChangeSliderValue() 
    {
        while (_healthBar.value != _health.Amount)
        {
            float normalizedTarget = Mathf.InverseLerp(_health.Min, _health.Max, _health.Amount);
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, normalizedTarget, _speed);
            yield return null;
        }
    }
}
