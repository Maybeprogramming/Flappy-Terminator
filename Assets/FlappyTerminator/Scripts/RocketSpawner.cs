using UnityEngine;

public class RocketSpawner : ObjectPool<Rocket>
{
    [SerializeField] private FlappyTerminator _flappyTerminator;
    [SerializeField] private ObjectPool<Rocket> _pool;
    [SerializeField] private float _speedRocket;
    
    private Rocket _rocket;

    private void Spawn()
    {
        _rocket = _pool.GetObject();
        _rocket.Init(this, _speedRocket);
        _rocket.transform.position = _flappyTerminator.transform.position;
        _rocket.transform.rotation = _flappyTerminator.transform.rotation;
        _rocket.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Spawn();
        }
    }
}