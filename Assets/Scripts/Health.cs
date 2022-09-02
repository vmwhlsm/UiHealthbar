using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public event UnityAction HealthChanged;

    public readonly float Max = 100;
    public readonly float Min = 0;

    public float Amount { get; private set; }

    private void Start()
    {
        Amount = Max;
    }

    public void Increase(int heal)
    {
        Amount = Mathf.Clamp(Amount + heal, Min, Max);
        HealthChanged.Invoke();
    }

    public void Reduce(int damage)
    {
        Amount = Mathf.Clamp(Amount - damage, Min, Max);
        HealthChanged.Invoke();
    }
}
