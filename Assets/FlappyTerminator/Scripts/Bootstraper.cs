using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    [SerializeField] private Weapon _playerWeapon;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private InputController _inputController;
    [SerializeField] private AudioHandler _audioHandler;
    [SerializeField] private HealthViewModel _playerHealth;
    [SerializeField] private LaserSpawner _laserSpawner;

    private void OnEnable()
    {
        _inputController.Jumped += _playerMover.OnJumpHandler;
        _inputController.Attacked += _playerWeapon.OnAttackHandler;
        _playerWeapon.Shooted += _audioHandler.OnRocketShoot;
        _playerHealth.Dead += _audioHandler.OnGameOver;
        _laserSpawner.Spawned += _audioHandler.OnLaserShoot;
    }

    private void OnDisable()
    {
        _inputController.Jumped -= _playerMover.OnJumpHandler;
        _inputController.Attacked -= _playerWeapon.OnAttackHandler;
        _playerWeapon.Shooted -= _audioHandler.OnRocketShoot;
        _playerHealth.Dead -= _audioHandler.OnGameOver;
        _laserSpawner.Spawned -= _audioHandler.OnLaserShoot;
    }
}