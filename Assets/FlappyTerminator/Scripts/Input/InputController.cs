using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private InputSystem _inputSystem;

    public event Action Attacked;
    public event Action Jumped;

    private void Awake()
    {
        _inputSystem = new InputSystem();
        //Enable();
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

    public void Enable() => 
        _inputSystem.Enable();

    public void Disable() => 
        _inputSystem.Disable();

    private void OnJump(UnityEngine.InputSystem.InputAction.CallbackContext context) => 
        Jumped?.Invoke();

    private void OnAttack(UnityEngine.InputSystem.InputAction.CallbackContext context) =>
        Attacked?.Invoke();
}