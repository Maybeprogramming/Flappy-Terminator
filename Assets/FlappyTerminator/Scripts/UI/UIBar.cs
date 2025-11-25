using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIBar : MonoBehaviour
{
    [SerializeField] private GameObject _element;
    [SerializeField] private List<GameObject> _elements;
    [SerializeField] private RectTransform _conteiner;

    private int _value;
    private int _maxValue;

    public int ActiveElements => _elements.Where(element => element.activeSelf == true).Count();
    public int ElementsCount => _elements.Count();

    private void Awake()
    {
        Init(5, 5);

    }

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
           _elements.Where(element => element.activeSelf == true).Last().SetActive(false);
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
            _elements.Where(element => element.activeSelf == false).Last().SetActive(true);
        }
        else
        {
            Debug.Log("Ёлементов максимум");
        }
    }

    private void Fill(int currentValue, int maxValue)
    {
        for (int i = 0; i < maxValue; i++)
        {
            var element = Instantiate(_element, _conteiner);
            _elements.Add(element);
            
            if (i < currentValue) 
                element.SetActive(true);
            else
                element.SetActive(false);
        }
    }
}