using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIBar : MonoBehaviour, IBarProvider
{
    private const int ZeroIconsCount = 0;

    [SerializeField] private Icon _iconPrefab;
    [SerializeField] private List<Icon> _icons;
    [SerializeField] private RectTransform _conteiner;

    private int _value;
    private int _maxValue;

    public int ActiveElements => _icons.Where(icon => icon.gameObject.activeSelf == true).Count();
    public int ElementsCount => _icons.Count();

    public void Init(int currentValue, int maxValue)
    {
        _value = currentValue;
        _maxValue = maxValue;

        Fill(_value, _maxValue);
    }

    public void SetCurrentValue(int newValue)
    {
        if (newValue < ZeroIconsCount)
            throw new ArgumentOutOfRangeException($"Method argument: {nameof(SetCurrentValue)} cannot be less than 0");
        else if (newValue > ElementsCount)
            throw new ArgumentOutOfRangeException($"The argument in the method: {nameof(SetCurrentValue)} cannot be greater than the maximum value ({ElementsCount}).");

        for (int i = 0; i < newValue; i++)
        {
            _icons[i].gameObject.SetActive(true);
        }

        for (int i = newValue; i < _maxValue; i++)
        {
            _icons[i].gameObject.SetActive(false);
        }
    }

    private void IconSetActive(bool isActive)
    {
        _icons.Where(icon => icon.gameObject.activeSelf == !isActive).Last().gameObject.SetActive(isActive);
    }

    private void Fill(int currentValue, int maxValue)
    {
        if (_icons.Count == 0)
            FillEmpty(currentValue, maxValue);
        else
            Reset();
    }

    private void Reset()
    {
        foreach (Icon icon in _icons)
            icon.gameObject.SetActive(true);
    }

    private void FillEmpty(int currentValue, int maxValue)
    {
        for (int i = 0; i < maxValue; i++)
        {
            Icon icon = Instantiate(_iconPrefab, _conteiner);
            _icons.Add(icon);

            if (i < currentValue)
                icon.gameObject.SetActive(true);
            else
                icon.gameObject.SetActive(false);
        }
    }
}