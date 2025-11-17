using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private InputSystem _inputSystem;

    public event Action Attacked;
    public event Action Jumped;

    private void Awake()
    {
        _inputSystem = new InputSystem();
    }

    private void OnEnable()
    {
        _inputSystem.Player.Attack.performed += OnAttack;
        _inputSystem.Player.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        _inputSystem.Player.Attack.performed -= OnAttack;
        _inputSystem.Player.Jump.performed -= OnJump;
    }

    public void Activate() => 
        _inputSystem.Enable();

    public void Deactivate() => 
        _inputSystem.Disable();

    private void OnJump(InputAction.CallbackContext context) => 
        Jumped?.Invoke();

    private void OnAttack(InputAction.CallbackContext context) =>
        Attacked?.Invoke();
}