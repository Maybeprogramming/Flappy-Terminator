using UnityEngine;

public class RocketSpawner : ObjectPool<Rocket>
{
    [SerializeField] private FlappyTerminator _flappyTerminator;
    //[SerializeField] private ObjectPool<Rocket> _pool;
    [SerializeField] private float _speedRocket;

    private void Spawn()
    {
        var rocket = GetObject();
        rocket.Init(this, _speedRocket);
        rocket.transform.position = _flappyTerminator.transform.position;
        rocket.transform.rotation = _flappyTerminator.transform.rotation;
        rocket.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Spawn();
        }
    }
}