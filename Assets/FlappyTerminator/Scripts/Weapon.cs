using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private RocketSpawner _spawner;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private float _timerBeetwenShootsInSeconds;
    [SerializeField] private float _timerReloadingInSeconds;

    [SerializeField] private int _ammoAmount;
    [SerializeField] private int _ammoMaxAmount;
    [SerializeField] private BarView _ammoView;

    private Ammo _ammo;
    private WaitForSeconds _delayReloadingAmmo;
    private WaitForSeconds _delayBeetwenShoots;
    private Coroutine _cooldowns;
    private Coroutine _reloadingAmmo;
    private bool _isCooldownsFinished;

    public event Action Shooted;

    public bool CanShoot => _ammo.Current.Value > 0 && _isCooldownsFinished;

    private void Awake()
    {
        _delayBeetwenShoots = new WaitForSeconds(_timerBeetwenShootsInSeconds);
        _delayReloadingAmmo = new WaitForSeconds(_timerReloadingInSeconds);
        _isCooldownsFinished = true;
        AmmoInitialize();
    }

    public void OnAttackHandler() =>
        Fire();

    private void AmmoInitialize()
    {
        _ammo = new Ammo(_ammoAmount, _ammoMaxAmount);
        _ammoView.Init(_ammo.Current, _ammo.Max);
    }

    private void Fire()
    {
        if (CanShoot)
        {
            _ammo.Reduce(1);
            _isCooldownsFinished = false;
            _spawner.Spawn(_startPosition, _projectileSpeed);
            _cooldowns ??= StartCoroutine(CountdownBeetwenShooting());

            Shooted?.Invoke();
        }

        if (_ammo.Current.Value == 0)
        {
            _reloadingAmmo ??= StartCoroutine(Reloading());
        }
    }

    private IEnumerator Reloading()
    {
        yield return _delayReloadingAmmo;
        AmmoInitialize();
        _reloadingAmmo = null;
    }

    private IEnumerator CountdownBeetwenShooting()
    {
        yield return _delayBeetwenShoots;
        _isCooldownsFinished = true;
        _cooldowns = null;
    }
}