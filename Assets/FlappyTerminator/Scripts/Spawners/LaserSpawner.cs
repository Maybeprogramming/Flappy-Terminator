using System;
using UnityEngine;

public class LaserSpawner : PoolEntities<Laser>, ISoundEffector
{
    public event Action SoundPlaying;

    public void Spawn(Transform enemyTransform)
    {
        var laser = Pool.Get();
        var laserStartPosition = enemyTransform.position;
        laser.transform.position = laserStartPosition;
        
        laser.Released += OnReleased;

        SoundPlaying?.Invoke();
    }

    private void OnReleased(Laser laser)
    {
        laser.transform.position = Position;
        laser.Released -= OnReleased;
        Pool.Release(laser);
    }
}