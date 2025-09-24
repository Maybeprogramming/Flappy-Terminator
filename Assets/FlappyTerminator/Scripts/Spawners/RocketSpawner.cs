using UnityEngine;

public class RocketSpawner : PoolEntities<Rocket>
{ 
    public void Spawn(Transform startPosition, float speed)
    {
        var rocket = Pool.Get();
        rocket.Init(speed);
        rocket.transform.position = startPosition.position;
        rocket.transform.rotation = startPosition.rotation;
        rocket.Dead += OnRocketEnd;
    }

    private void OnRocketEnd(Rocket rocket)
    {
        rocket.transform.position = Position;
        rocket.Dead -= OnRocketEnd;
        Pool.Release(rocket);
    }
}