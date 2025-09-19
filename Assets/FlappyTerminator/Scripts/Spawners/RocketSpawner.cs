using System;
using UnityEngine;

public class RocketSpawner : PoolEntities<Rocket>, ISoundPlayable
{
    [Header("Спавнер ракет")]
    [SerializeField] private FlappyTerminator _player;
    [SerializeField] private float _speedRocket;

    public event Action RocketSpawned;
    public event Action SoundPlayed;

    private void Spawn()
    {
        var rocket = Pool.Get();
        rocket.Init(_speedRocket);
        rocket.transform.position = _player.transform.position;
        rocket.transform.rotation = _player.transform.rotation;
        rocket.FuelEnded += OnRocketEnd;

        RocketSpawned?.Invoke();
        SoundPlayed?.Invoke();
    }

    private void OnRocketEnd(Rocket rocket)
    {
        rocket.FuelEnded -= OnRocketEnd;
        Pool.Release(rocket);
    }

    public void OnAttackHandler() =>
        Spawn();
}