using System;
using UnityEngine;

public class Weapon: MonoBehaviour
{
    [SerializeField] private RocketSpawner _spawner;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private float _projectileSpeed;

    private void Fire()
    {
        _spawner.Spawn(_startPosition, _projectileSpeed);
    }

    public void OnAttackHandler() =>
        Fire();
}