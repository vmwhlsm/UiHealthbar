using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public event UnityAction HealthChanged;

    public readonly int Max = 100;
    public readonly int Min = 0;
    public int Amount { get; private set; }

    private void Start()
    {
        Amount = Max;
    }

    public void Increase(int heal)
    {
        Amount = Mathf.Clamp(Amount + heal, Min, Max);
        HealthChanged?.Invoke();
    }

    public void Reduce(int damage)
    {
        Amount = Mathf.Clamp(Amount - damage, Min, Max);
        HealthChanged?.Invoke();
    }
}
