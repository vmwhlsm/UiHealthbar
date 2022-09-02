using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Button _increase;
    [SerializeField] private Button _reduce;
    
    private float _step = 10;

    public float Max { get => 100; }
    public float Min { get => 0; }
    public float Amount { get; private set; }

    private void Start()
    {
        Amount = Max;
        _increase.onClick.AddListener(Increase);
        _reduce.onClick.AddListener(Reduce);
    }

    private void Increase()
    {
        if(Amount + _step > Max)
        {
            Amount = Max;
        }
        else
        {
            Amount += _step;
        }
    }

    private void Reduce()
    {
        if (Amount - _step < Min)
        {
            Amount = Min;
        }
        else
        {
            Amount -= _step;
        }
    }

    private void OnDestroy()
    {
        _increase.onClick.RemoveListener(Increase);
        _reduce.onClick.RemoveListener(Reduce);
    }
}
