using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _xOffset;
    [SerializeField] private Transform _cameraPosition;

    public event Action<Enemy> Dead;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Rocket>(out _))
        {
            Dead?.Invoke(this);
        }
    }

    public void Init(Transform cameraPosition, LaserSpawner laserSpawner)
    {
        _cameraPosition = cameraPosition;
        var attacker = GetComponent<Atacker>();
        attacker.Init(laserSpawner);
    }


    private void Update()
    {
        var position = transform.position;
        position.x = _cameraPosition.transform.position.x + _xOffset;
        
        transform.position = position;
    }
}