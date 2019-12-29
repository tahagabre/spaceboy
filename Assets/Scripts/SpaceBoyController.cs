using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Delegate to all components
public class SpaceBoyController : MonoBehaviour
{
    private InputController inputController;
    private MovementController movementController;
    private FuelController fuelController;
    //private HealthController healthController;

    void Awake()
    {
        inputController = GetComponent<InputController>();
        movementController = GetComponent<MovementController>();
        fuelController = GetComponent<FuelController>();
        //healthController = GetComponent<HealthController>();
    }

    // Logic for disabling input here to prevent fuelController and SpaceBoyController from having references to each other
    private void Update()
    {
        if (fuelController.GetFuelState() == FuelController.FuelState.empty) {
            inputController.enabled = false;
        }
        else
        {
            inputController.enabled = true;
        }
    }

    public void MoveInputOcurred(float input)
    {
        fuelController.SetFuelState(FuelController.FuelState.depleting);
        movementController.SetInputVelocity(input);
    }

    public void MoveInputCancelled()
    {
        fuelController.SetFuelState(FuelController.FuelState.replenishing);
        movementController.ResetInputVelocity();
    }
}
