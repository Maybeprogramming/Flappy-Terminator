using System;
using UnityEngine;
using UnityEngine.Pool;

public class RocketSpawner : PoolEntities<Rocket>
{
    [Header("Спавнер ракет")]
    [SerializeField] private FlappyTerminator _player;
    [SerializeField] private float _speedRocket;

    public event Action RocketSpawned;

    private protected override void PoolInit()
    {
        Pool = new ObjectPool<Rocket>(() => Create(),
                            (rocket) => PutEntity(rocket),
                            (rocket) => rocket.gameObject.SetActive(false),
                            (rocket) => Destroy(rocket),
                            true,
                            PoolDefaultCapacity,
                            PoolMaxCapacity);
    }

    private void Spawn()
    {
        var rocket = Pool.Get();
        rocket.Init(_speedRocket);
        rocket.transform.position = _player.transform.position;
        rocket.transform.rotation = _player.transform.rotation;
        rocket.FuelEnded += OnRocketEnd;

        RocketSpawned?.Invoke();
    }

    private void OnRocketEnd(Rocket rocket)
    {
        rocket.FuelEnded -= OnRocketEnd;
        Pool.Release(rocket);
    }

    //Перенести в инпут и сделать метод обработчик
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Spawn();
        }
    }
}