using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(CollisionHandler))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _healthValue;
    [SerializeField] private int _maxHealthValue;
    [SerializeField] private Crosshair _crosshair;

    [SerializeField] private BarView _hpBar;
    [SerializeField] private BarView _ammoBar;

    private Health _health;

    private PlayerMover _flappyMover;
    private ScoreCounter _scoreCounter;
    private CollisionHandler _collisionHandler;

    public event Action GameOver;

    private void Awake()
    {
        _health = new Health(_healthValue, _maxHealthValue);
        _hpBar.Init(_health.Current, _health.Max);
        _ammoBar.Init(new ReactiveVariable<int>(3), new ReactiveVariable<int>(3));

        _scoreCounter = GetComponent<ScoreCounter>();
        _collisionHandler = GetComponent<CollisionHandler>();
        _flappyMover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += OnProcessCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= OnProcessCollision;
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _flappyMover.Reset();
    }

    private void OnProcessCollision(IDamageProvider damageProvider)
    {
        if (damageProvider is Laser)
        {
            if (_health.isAlive)            
                _health.Reduce(damageProvider.Damage);
            else
                GameOver?.Invoke();                    
        }
    }
}