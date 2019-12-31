using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Delegate to all components
public class SpaceBoyController : Collidable
{
    private InputController inputController;
    private MovementController movementController;
    private FuelController fuelController;
    private HealthController healthController;

    void Awake()
    {
        collidableType = CollidableType.Player;
        inputController = GetComponent<InputController>();
        movementController = GetComponent<MovementController>();
        fuelController = GetComponent<FuelController>();
        healthController = GetComponent<HealthController>();
    }

    // Logic for disabling input here to prevent fuelController and SpaceBoyController from having references to each other
    private void Update()
    {
        ControlInput();
        CheckCollision();
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

    private void ControlInput()
    {
        if (fuelController.GetFuelState() == FuelController.FuelState.empty)
        {
            inputController.enabled = false;
        }
        else
        {
            inputController.enabled = true;
        }
    }

    private void CheckCollision()
    {

    }

    public override void CollisionOccurred(CollidableType collidableType)
    {
        switch (collidableType)
        {
            case CollidableType.Asteroid:
                healthController.DamagePlayer(AsteroidController.DAMAGE);
                break;
        }
    }
}
