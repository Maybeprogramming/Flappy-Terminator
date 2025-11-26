using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIBar : MonoBehaviour, IBarProvider
{
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

    public void Reduce()
    {
        if (ActiveElements > 0)
        {
            IconSetActive(false);
        }
        else
        {
            Debug.Log("Ёлементов 0");
        }
    }

    public void Increase()
    {
        if (ActiveElements < ElementsCount)
        {
            IconSetActive(true);
        }
        else
        {
            Debug.Log("Ёлементов максимум");
        }
    }

    private void IconSetActive(bool isActive)
    {
        _icons.Where(icon => icon.gameObject.activeSelf == !isActive).Last().gameObject.SetActive(isActive);
    }

    private void Fill(int currentValue, int maxValue)
    {
        if (_icons.Count == 0)
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
        else
        {
            foreach (Icon icon in _icons)
            {
                icon.gameObject.SetActive(true);
            }
        }
    }
}