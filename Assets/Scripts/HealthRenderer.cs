using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthRenderer : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Coroutine _sliderValueChange;
    private Slider _healthBar;
    private float _speed = 0.05f;

    private void Start()
    {       
        _healthBar = GetComponent<Slider>();
        _healthBar.maxValue = _health.Max;
        _healthBar.value = _healthBar.maxValue;
        _health.HealthChanged += StartSliderChanging;
    }

    public void StartSliderChanging()
    {
        if(_sliderValueChange != null)
        {
            StopCoroutine(_sliderValueChange);
        }

        _sliderValueChange = StartCoroutine(ChangeSliderValue());
    }

    private IEnumerator ChangeSliderValue() 
    {
        while (_healthBar.value != _health.Amount)
        {           
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _health.Amount, _speed);
            yield return null;
        }
    }
}
