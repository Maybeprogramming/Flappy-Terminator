using System;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float moveDirection;

    public event Action<Laser> Released;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Rocket>(out _) || collision.gameObject.TryGetComponent<FlappyTerminator>(out _))
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
}