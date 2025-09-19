using System;
using UnityEngine;

public class LaserSpawner : PoolEntities<Laser>, ISoundPlayable
{
    public event Action LaserSpawned;
    public event Action SoundPlayed;

    public void Spawn(Transform enemyTransform)
    {
        var laser = Pool.Get();
        var laserPosition = enemyTransform.position;
        laser.transform.position = laserPosition;
        
        laser.Released += OnReleased;

        LaserSpawned?.Invoke();
        SoundPlayed?.Invoke();
    }

    private void OnReleased(Laser laser)
    {
        laser.Released -= OnReleased;
        Pool.Release(laser);
    }
}