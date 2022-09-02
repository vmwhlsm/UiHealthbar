using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthRenderer : MonoBehaviour
{
    [SerializeField] private Health _health;
    private Slider _healthBar;
    private float _speed = 0.001f;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();       
    }

    private void Update()
    {
        _healthBar.value = Mathf.MoveTowards(_healthBar.value, Mathf.InverseLerp(_health.Min, _health.Max, _health.Amount), _speed); 
    }
}
