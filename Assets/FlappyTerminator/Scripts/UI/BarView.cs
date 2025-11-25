using UnityEngine;

public class BarView : MonoBehaviour
{
    private ReactiveVariable<int> _maxValue;
    private ReactiveVariable<int> _currentValue;

    private void OnDestroy()
    {
        _currentValue.Changed -= OnCurrentValueChanched;
        _maxValue.Changed -= OnMaxValueChanched;
    }

    public void Init(ReactiveVariable<int> currentValue, ReactiveVariable<int> maxValue)
    {
        _currentValue = currentValue;
        _maxValue = maxValue;

        _currentValue.Changed += OnCurrentValueChanched;
        _maxValue.Changed += OnMaxValueChanched;

        UpdateValue(_currentValue.Value, _maxValue.Value);
    }

    private void UpdateValue(int currentValue, int maxValue)
    {
        Debug.LogError($"Метод ({nameof(UpdateValue)}) класса ({nameof(BarView)}) не реализован!");
    }

    private void OnMaxValueChanched(int oldValue, int newValue) =>
        UpdateValue(_currentValue.Value, newValue);

    private void OnCurrentValueChanched(int oldValue, int newValue) =>
        UpdateValue(newValue, _maxValue.Value);
}