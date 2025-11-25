using System;
using System.Collections;
using UnityEngine;

public class Rocket : Ammo
{
    [SerializeField] private float _delayFuelEnd;
    [SerializeField] private int _damage;
    private WaitForSeconds _wait;
    private float _speed;

    public override int Damage => _damage;
    public event Action<Rocket> Dead;

    private void OnEnable()
    {
        _wait = new WaitForSeconds(_delayFuelEnd);
        StartCoroutine(FuelEnding());
    }

    private void Update()
    {
        Moving();
    }

    private void Moving()
    {
        transform.position += transform.right * Time.deltaTime * _speed;
    }

    public void Init(float speed)
    {
        _speed = speed;
    }

    private IEnumerator FuelEnding()
    {
        yield return _wait;
        Dead?.Invoke(this);
    }

    public override void Reset()
    {
        Dead?.Invoke(this);
    }
}