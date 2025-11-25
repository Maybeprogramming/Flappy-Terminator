using UnityEngine;

public class BarView : MonoBehaviour
{
    [SerializeField] private UIBar _bar;

    private ReactiveVariable<int> _maxValue;
    private ReactiveVariable<int> _currentValue;
    private IBarProvider _barUIProvider;

    private void Start()
    {
        _barUIProvider = _bar;
    }

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

        _barUIProvider.Init(_currentValue.Value, _maxValue.Value);
    }

    private void UpdateValue(int oldValue, int newValue)
    {
        if (newValue - oldValue == 1)
        {
            _barUIProvider.Increase();
        }
        else if (newValue - oldValue == -1)
        {
            _barUIProvider.Reduce();
        }
        else
        {
            Debug.LogError($"Значения не изменились");
        }
    }

    private void OnMaxValueChanched(int oldValue, int newValue) =>
        UpdateValue(_currentValue.Value, newValue);

    private void OnCurrentValueChanched(int oldValue, int newValue) =>
        _barUIProvider.Init(_currentValue.Value, newValue);
}