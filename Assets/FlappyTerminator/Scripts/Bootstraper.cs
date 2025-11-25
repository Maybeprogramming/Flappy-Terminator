using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    [SerializeField] private Weapon _playerWeapon;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private InputController _inputController;

    private void OnEnable()
    {
        _inputController.Jumped += _playerMover.OnJumpHandler;
        _inputController.Attacked += _playerWeapon.OnAttackHandler;
    }

    private void OnDisable()
    {
        _inputController.Jumped -= _playerMover.OnJumpHandler;
        _inputController.Attacked -= _playerWeapon.OnAttackHandler;
    }
}