using System;
using UnityEngine;

public class Laser : MonoBehaviour, IInteractable
{
    [SerializeField] private float _speed;
    [SerializeField] private float moveDirection;

    public event Action<Laser> Released;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Rocket>(out _) || collision.gameObject.TryGetComponent<FlappyTerminator>(out _) || collision.gameObject.TryGetComponent<ObjectRemover>(out _))
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