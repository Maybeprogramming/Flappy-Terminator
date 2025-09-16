using UnityEngine;

public class RocketSpawner : ObjectPool<Rocket>
{
    [SerializeField] private FlappyHunter _bird;
    [SerializeField] private ObjectPool<Rocket> _pool;
    [SerializeField] private float _speedRocket;
    
    private Rocket _rocket;

    private void Spawn()
    {
        _rocket = _pool.GetObject();
        _rocket.Init(this, _speedRocket);
        _rocket.transform.position = _bird.transform.position;
        _rocket.transform.rotation = _bird.transform.rotation;
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