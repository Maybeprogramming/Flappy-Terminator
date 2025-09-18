using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private FlappyTerminator _flappyTerminator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;

    [Header("Спавнеры")]
    [SerializeField] private RocketSpawner _rocketSpawner;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private LaserSpawner _laserSpawner;
    [SerializeField] private PipeSpawner _pipeSpawner;

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
        //_laserSpawner.Reset();
        //_pipeSpawner.Reset();
        //_enemySpawner.Reset();
        //_rocketSpawner.Reset();
    }
}
