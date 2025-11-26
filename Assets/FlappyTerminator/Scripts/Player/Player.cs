using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover), 
                  typeof(ScoreCounter), 
                  typeof(HealthViewModel))]
public class Player : MonoBehaviour
{
    [SerializeField] private Crosshair _crosshair;
    [SerializeField] private BarView _ammoBar;
   
    private HealthViewModel _healthViewModel;
    private PlayerMover _flappyMover;
    private ScoreCounter _scoreCounter;

    public event Action GameOver;

    private void Awake()
    {        
        _ammoBar.Init(new ReactiveVariable<int>(3), new ReactiveVariable<int>(3));

        _scoreCounter = GetComponent<ScoreCounter>();
        _flappyMover = GetComponent<PlayerMover>();
        _healthViewModel = GetComponent<HealthViewModel>();
    }

    private void OnEnable()
    {
        _healthViewModel.Dead += OnGameEnd;
    }

    private void OnDisable()
    {
        _healthViewModel.Dead -= OnGameEnd;
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _flappyMover.Reset();
        _healthViewModel.Reset();
        _crosshair.gameObject.SetActive(true);
    }

    private void OnGameEnd()
    {
        _crosshair.gameObject.SetActive(false);
        GameOver?.Invoke();
    }
}