using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIBar : MonoBehaviour, IBarProvider
{
    [SerializeField] private GameObject _iconPrefab;
    [SerializeField] private List<GameObject> _icons;
    [SerializeField] private RectTransform _conteiner;

    private int _value;
    private int _maxValue;

    public int ActiveElements => _icons.Where(element => element.activeSelf == true).Count();
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
        _icons.Where(element => element.activeSelf == !isActive).Last().SetActive(isActive);
    }

    private void Fill(int currentValue, int maxValue)
    {
        for (int i = 0; i < maxValue; i++)
        {
            var element = Instantiate(_iconPrefab, _conteiner);
            _icons.Add(element);
            
            if (i < currentValue) 
                element.SetActive(true);
            else
                element.SetActive(false);
        }
    }
}