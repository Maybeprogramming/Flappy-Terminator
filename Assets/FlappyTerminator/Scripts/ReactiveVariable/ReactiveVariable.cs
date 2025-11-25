using System;
using System.Collections.Generic;

public class ReactiveVariable<T>
{
    private T _value;
    private readonly IEqualityComparer<T> _comparer;

    public event Action<T, T> Changed;

    public ReactiveVariable() : this(default) { }

    public ReactiveVariable(T value) : this(value, default) { }

    public ReactiveVariable(T value, IEqualityComparer<T> comparer)
    {
        _value = value;
        _comparer = comparer;
    }

    public T Value
    {
        get => _value;
        set
        {
            T oldValue = _value;
            _value = value;

            if (_comparer.Equals(oldValue, value) == false)            
                Changed?.Invoke(oldValue, _value);
        }
    }
}