using System;
using UnityEngine;

[RequireComponent(typeof(CollisionHandler))]
public class HealthViewModel : MonoBehaviour
{
    [SerializeField] private int _healthValue;
    [SerializeField] private int _maxHealthValue;
    [SerializeField] private BarView _hpBar;

    private Health _health;
    private CollisionHandler _collisionHandler;

    public event Action Dead;

    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += OnProcessCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= OnProcessCollision;
    }

    private void OnProcessCollision(IDamageProvider damageProvider)
    {
        if (damageProvider is Laser)
        {
            _health.Reduce(damageProvider.Damage);

            if (_health.isAlive == false)
                Dead?.Invoke();
        }
    }

    public void SetupDefault()
    {
        _health = new Health(_healthValue, _maxHealthValue);
        _hpBar.Init(_health.Current, _health.Max);
    }
}