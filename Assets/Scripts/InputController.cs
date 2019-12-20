using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private InputAction moveInput;
    [SerializeField] private MovementController movementController;
    
    private void Awake()
    {
        moveInput.performed += context => movementController.SetInputVelocity(context.ReadValue<Vector2>().x);
        moveInput.canceled += context => movementController.ResetInputVelocity();
    }

    private void OnEnable()
    {
        moveInput.Enable();
    }

    private void OnDisable()
    {
        moveInput.Disable();
    }
}
