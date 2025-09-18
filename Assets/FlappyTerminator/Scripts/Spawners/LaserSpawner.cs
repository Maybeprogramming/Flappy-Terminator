using System;
using UnityEngine;
using UnityEngine.Pool;

public class LaserSpawner : PoolEntities<Laser>
{
    public event Action LaserSpawned;

    private protected override void PoolInit()
    {
        Pool = new ObjectPool<Laser>(() => Create(),
                            (laser) => PutEntity(laser),
                            (laser) => laser.gameObject.SetActive(false),
                            (laser) => Destroy(laser),
                            true,
                            PoolDefaultCapacity,
                            PoolMaxCapacity);
    }

    public void Spawn(Transform enemyTransform)
    {
        var laser = Pool.Get();
        var laserPosition = enemyTransform.position;
        laser.transform.position = laserPosition;
        
        laser.Released += OnReleased;

        LaserSpawned?.Invoke();
    }

    private void OnReleased(Laser laser)
    {
        laser.Released -= OnReleased;
        Pool.Release(laser);
    }
}