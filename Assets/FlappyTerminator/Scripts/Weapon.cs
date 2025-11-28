using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private RocketSpawner _spawner;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private float _delayReloading;

    private WaitForSeconds _delayTime;
    private Coroutine _firing;
    private bool _isReadyShooting;

    private void Awake()
    {
        _delayTime = new WaitForSeconds(_delayReloading);
        _isReadyShooting = true;
    }

    private void Fire()
    {
        if (_isReadyShooting)
        {
            _isReadyShooting = false;
            _spawner.Spawn(_startPosition, _projectileSpeed);
            _firing ??= StartCoroutine(Countdown());
        }
    }

    public void OnAttackHandler() => 
        Fire();

    private IEnumerator Countdown()
    {
        yield return _delayTime;
        _isReadyShooting = true;
        _firing = null;
    }
}