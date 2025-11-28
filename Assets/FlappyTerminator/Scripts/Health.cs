using System;
using UnityEngine;

public class Health
{
    private const int ZeroHealth = 0;

    public Health(int currentValue, int maxValue)
    {
        Current = new ReactiveVariable<int>(currentValue);
        Max = new ReactiveVariable<int>(maxValue);
    }

    public ReactiveVariable<int> Current { get; }
    public ReactiveVariable<int> Max { get; }
    public bool IsAlive => Current.Value > ZeroHealth;

    public void Reduce(int value)
    {
        if (value < ZeroHealth)
            throw new ArgumentOutOfRangeException(nameof(value));

        if (IsAlive)
            Current.Value = Mathf.Clamp(Current.Value - value, ZeroHealth, Max.Value);
    }

    public void Increase(int value)
    {
        if (value < ZeroHealth)
            throw new ArgumentOutOfRangeException(nameof(value));

        if (IsAlive && Current.Value + value <= Max.Value)
            Current.Value = Mathf.Clamp(Current.Value + value, ZeroHealth, Max.Value);
    }
}