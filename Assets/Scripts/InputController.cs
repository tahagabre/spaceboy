using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private InputAction moveInput;
    [SerializeField] private SpaceBoyController spaceBoyController;
    
    private void Awake()
    {
        moveInput.performed += context => spaceBoyController.MoveInputOcurred(context.ReadValue<Vector2>().x);
        moveInput.canceled += context => spaceBoyController.MoveInputCancelled();
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
