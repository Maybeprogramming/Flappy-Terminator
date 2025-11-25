using System;
using UnityEngine;

public class Laser : Ammo
{
    [SerializeField] private float _speed;
    [SerializeField] private float moveDirection;
    [SerializeField] private int _damage;

    public override int Damage => _damage;

    public event Action<Laser> Released;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Rocket>(out _) || collision.gameObject.TryGetComponent<Player>(out _))
        {
            Released?.Invoke(this);
        }
    }

    private void Update()
    {
        Moving();
    }

    private void Moving()
    {
        transform.position += (transform.right * Time.deltaTime * _speed) * moveDirection;
    }

    public override void Reset()
    {
        Released?.Invoke(this);
    }
}