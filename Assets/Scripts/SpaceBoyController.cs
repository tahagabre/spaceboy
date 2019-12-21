using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Delegate to all components
public class SpaceBoyController : MonoBehaviour
{

    private InputController inputController;
    private MovementController movementController;
    private FuelController fuelController;

    void Awake()
    {
        inputController = GetComponent<InputController>();
        movementController = GetComponent<MovementController>();
        fuelController = GetComponent<FuelController>();
    }

    public void MoveInputOcurred(float input)
    {
        fuelController.DepleteFuel();
        movementController.SetInputVelocity(input);
    }

    public void MoveInputCancelled()
    {
        fuelController.ReplenishFuel();
        movementController.ResetInputVelocity();
    }
}
