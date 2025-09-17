using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private FlappyTerminator _flappyTerminator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;
    [Header("Спавнеры")]
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private PipeSpawner _pipeSpawner;
    [SerializeField] private RocketSpawner _rocketSpawner;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
        _flappyTerminator.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
        _flappyTerminator.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _endGameScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _endGameScreen.Close();
        StartGame();
    }
    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _flappyTerminator.Reset();
        _rocketSpawner.Reset();
        _enemySpawner.Reset();
        _pipeSpawner.Reset();
    }
}
