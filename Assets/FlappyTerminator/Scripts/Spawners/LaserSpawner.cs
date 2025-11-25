using System;
using UnityEngine;

public class LaserSpawner : PoolEntities<Laser>
{
    public void Spawn(Transform enemyTransform)
    {
        var laser = Pool.Get();
        var laserStartPosition = enemyTransform.position;
        laser.transform.position = laserStartPosition;
        
        laser.Released += OnReleased;
    }

    private void OnReleased(Laser laser)
    {
        laser.transform.position = Position;
        laser.Released -= OnReleased;
        Pool.Release(laser);
    }
}