using System;
using UnityEditor;
using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    [Header("Сущности")]
    [SerializeField] private FlappyTerminator _player;

    [Header("Input игрока")]
    [SerializeField] private InputController _inputController;
    [SerializeField] private FlappyMover _flappyMover;

    [Header("Звуковые эффекты")]
    [SerializeField] private SoundPlayer _soundPlayer;
    [SerializeField] private SoundEffector _playerSoundEffector;
    [SerializeField] private SoundEffector _enemySoundEffector;
    [SerializeField] private SoundEffector _gameoverSoundEffector;

    [Header("Спавнеры")]
    [SerializeField] private RocketSpawner _rocketSpawner;
    [SerializeField] private LaserSpawner _laserSpawner;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private PipeSpawner _pipeSpawner;

    [Header("Игра")]
    [SerializeField] private Game _game;

    private void Start()
    {
        InitSoundPlayer();
    }

    private void OnEnable()
    {
        _inputController.Jumped += _flappyMover.OnJumpHandler;
        _inputController.Attacked += _rocketSpawner.OnAttackHandler;
        //_game.Started += OnSpawnersReseted;
    }

    private void OnDisable()
    {
        _inputController.Jumped -= _flappyMover.OnJumpHandler;
        _inputController.Attacked -= _rocketSpawner.OnAttackHandler;
        //_game.Started -= OnSpawnersReseted;
    }

    private void OnSpawnersReseted()
    {
        _rocketSpawner.Clear();
        _laserSpawner.Clear();
        _enemySpawner.Clear();
        _pipeSpawner.Clear();
    }

    private void InitSoundPlayer()
    {
        _playerSoundEffector.Init(_soundPlayer, _rocketSpawner);
        _enemySoundEffector.Init(_soundPlayer, _laserSpawner);
        _gameoverSoundEffector.Init(_soundPlayer, _player);
    }
}