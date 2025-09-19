using UnityEditor;
using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    [Header("Сущности")]
    [SerializeField] private FlappyTerminator _player;

    [Header("Input игрока")]
    [SerializeField] private InputController _inputController;
    [SerializeField] private FlappyMover _flappyMover;
    [SerializeField] private RocketSpawner _rocketSpawner;
    [SerializeField] private LaserSpawner _laserSpawner;

    [Header("Звуковые эффекты")]
    [SerializeField] private SoundPlayer _soundPlayer;
    [SerializeField] private SoundEffector _playerSoundEffector;
    [SerializeField] private SoundEffector _enemySoundEffector;
    [SerializeField] private SoundEffector _gameoverSoundEffector;

    private void Start()
    {
        InitInputController();
        InitSoundPlayer();
    }

    private void InitInputController()
    {
        _inputController.Jumped += _flappyMover.OnJumpHandler;
        _inputController.Attacked += _rocketSpawner.OnAttackHandler;
    }

    private void InitSoundPlayer()
    {
        _playerSoundEffector.Init(_soundPlayer, _rocketSpawner);
        _enemySoundEffector.Init(_soundPlayer, _laserSpawner);
        _gameoverSoundEffector.Init(_soundPlayer, _player);
    }
}