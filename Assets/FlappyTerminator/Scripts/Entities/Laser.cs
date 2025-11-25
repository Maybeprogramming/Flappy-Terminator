using System;
using UnityEngine;

public class Laser : Ammo
{
    [SerializeField] private float _speed;
    [SerializeField] private float moveDirection;

    [field: SerializeField] public override int Damage { get; }

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