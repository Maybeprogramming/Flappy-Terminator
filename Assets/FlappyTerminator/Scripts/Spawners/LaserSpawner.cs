using System;
using UnityEngine;

public class LaserSpawner : PoolEntities<Laser>, ISoundPlayable
{
    public event Action LaserSpawned;
    public event Action SoundPlayed;

    public Vector3 Position => transform.position;

    public void Spawn(Transform enemyTransform)
    {
        var laser = Pool.Get();
        var laserStartPosition = enemyTransform.position;
        laser.transform.position = laserStartPosition;
        
        laser.Released += OnReleased;

        LaserSpawned?.Invoke();
        SoundPlayed?.Invoke();
    }

    private void OnReleased(Laser laser)
    {
        laser.transform.position = Position;
        laser.Released -= OnReleased;
        Pool.Release(laser);
    }
}