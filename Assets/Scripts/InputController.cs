using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private InputAction moveInput;
    [SerializeField] private InputAction dashInput;
    [SerializeField] private SpaceBoyController spaceBoyController;
    
    private void Awake()
    {
        moveInput.performed += context => spaceBoyController.MoveInputOcurred(context.ReadValue<Vector2>().x, context.ReadValue<Vector2>().y);
        moveInput.canceled += context => spaceBoyController.MoveInputCancelled();

        dashInput.performed += context => spaceBoyController.DashInputOcurred();
        dashInput.canceled += context => spaceBoyController.DashInputCancelled();
    }

    private void OnEnable()
    {
        moveInput.Enable();
        dashInput.Enable();
    }

    private void OnDisable()
    {
        moveInput.Disable();
        dashInput.Disable();
    }
}
