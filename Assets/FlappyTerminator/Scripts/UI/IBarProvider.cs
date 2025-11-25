public interface IBarProvider
{
    void Init(int currentValue, int maxValue);
    void Reduce();
    void Increase();
}
