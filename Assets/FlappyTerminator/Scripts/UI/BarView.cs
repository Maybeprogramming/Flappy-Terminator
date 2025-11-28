using UnityEngine;

public class BarView : MonoBehaviour
{
    [SerializeField] private UIBar _bar;

    private IReactiveVariable<int> _maxValue;
    private IReactiveVariable<int> _currentValue;
    private IBarProvider _barUIProvider;

    private void OnDestroy()
    {
        _currentValue.Changed -= OnCurrentValueChanched;
        _maxValue.Changed -= OnMaxValueChanched;
    }

    public void Init(IReactiveVariable<int> currentValue, IReactiveVariable<int> maxValue)
    {
        _barUIProvider = _bar;
        _currentValue = currentValue;
        _maxValue = maxValue;

        _currentValue.Changed += OnCurrentValueChanched;
        _maxValue.Changed += OnMaxValueChanched;

        _barUIProvider.Init(currentValue.Value, maxValue.Value);
    }

    private void UpdateValue(int oldValue, int newValue)
    {
        if (newValue != oldValue)
        {
            _barUIProvider.SetCurrentValue(newValue);
        }
    }

    private void UpdateMaxValue(int newValue)
    {
        _barUIProvider.Init(_currentValue.Value, newValue);
    }

    private void OnMaxValueChanched(int oldValue, int newValue) =>
        UpdateMaxValue(newValue);

    private void OnCurrentValueChanched(int oldValue, int newValue) =>
        UpdateValue(oldValue, newValue);
}