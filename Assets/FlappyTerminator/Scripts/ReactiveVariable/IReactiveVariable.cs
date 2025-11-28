using System;

public interface IReactiveVariable<T>
{
    event Action<T, T> Changed;
    T Value { get; }
}