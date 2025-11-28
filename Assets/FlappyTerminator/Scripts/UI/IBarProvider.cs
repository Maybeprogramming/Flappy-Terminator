public interface IBarProvider
{
    void Init(int currentValue, int maxValue);
    void SetCurrentValue(int newValue);
}