using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    [Header("Игрок")]
    [SerializeField] private Player _player;
    [SerializeField] private Weapon _playerWeapon;
    [SerializeField] private PlayerMover _playerMover;

    [Header("Input")]
    [SerializeField] private InputController _inputController;

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
        _inputController.Jumped += _playerMover.OnJumpHandler;
        _inputController.Attacked += _playerWeapon.OnAttackHandler;
        _game.Started += OnSpawnersReseted;
    }

    private void OnDisable()
    {
        _inputController.Jumped -= _playerMover.OnJumpHandler;
        _inputController.Attacked -= _playerWeapon.OnAttackHandler;
        _game.Started -= OnSpawnersReseted;
    }

    private void OnSpawnersReseted()
    {
        _rocketSpawner.Reset();
        _laserSpawner.Reset();
        _enemySpawner.Reset();
        _pipeSpawner.Reset();
    }

    private void InitSoundPlayer()
    {
        _playerSoundEffector.Init(_soundPlayer, _playerWeapon);
        _enemySoundEffector.Init(_soundPlayer, _laserSpawner);
        _gameoverSoundEffector.Init(_soundPlayer, _player);
    }
}