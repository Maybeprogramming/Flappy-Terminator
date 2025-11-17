using System;
using UnityEngine;

public class Weapon: MonoBehaviour, ISoundEffector
{
    [SerializeField] private RocketSpawner _spawner;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private float _projectileSpeed;

    public event Action SoundPlaying;

    private void Fire()
    {
        _spawner.Spawn(_startPosition, _projectileSpeed);
        SoundPlaying?.Invoke();
    }

    public void OnAttackHandler() =>
        Fire();
}