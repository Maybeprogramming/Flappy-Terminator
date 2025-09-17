using System;
using UnityEngine;

public class LaserSpawner : ObjectPool<Laser>
{
    internal void Spawn(Transform enemyTransform)
    {
        var laser = GetObject();
        var laserPosition = enemyTransform.position;
        laser.transform.position = laserPosition;
        laser.Init(this);
        laser.gameObject.SetActive(true);
    }
}