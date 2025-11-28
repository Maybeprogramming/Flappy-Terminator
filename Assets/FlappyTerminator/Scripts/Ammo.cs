using System;
using UnityEngine;

public class Ammo
{
    private const int ZeroAmmo = 0;

    public Ammo(int currentValue, int maxValue)
    {
        Current = new ReactiveVariable<int>(currentValue);
        Max = new ReactiveVariable<int>(maxValue);
    }

    public ReactiveVariable<int> Current { get; }
    public ReactiveVariable<int> Max { get; }
    public bool isAlive => Current.Value > ZeroAmmo;

    public void Reduce(int value)
    {
        if (value < ZeroAmmo)
            throw new ArgumentOutOfRangeException(nameof(value));

        if (isAlive)
            Current.Value = Mathf.Clamp(Current.Value - value, ZeroAmmo, Max.Value);
    }

    public void Increase(int value)
    {
        if (value < ZeroAmmo)
            throw new ArgumentOutOfRangeException(nameof(value));

        if (isAlive && Current.Value + value <= Max.Value)
            Current.Value = Mathf.Clamp(Current.Value + value, ZeroAmmo, Max.Value);
    }
}
