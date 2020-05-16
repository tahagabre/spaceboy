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
    }

    public void MoveInputOcurred(float x, float y)
    {
        movementController.SetState(MovementController.MovementState.moving);
        fuelController.SetFuelState(FuelController.FuelState.depleting);
        movementController.SetInputVelocity(x, y);
    }

    public void MoveInputCancelled()
    {
        movementController.SetState(MovementController.MovementState.none);
        fuelController.SetFuelState(FuelController.FuelState.replenishing);
        movementController.ResetInputVelocity();
    }

    public void DashInputOcurred()
    {
        movementController.SetState(MovementController.MovementState.dashing);
    }

    public void DashInputCancelled()
    {
        print("Dash input cancelled");
        movementController.SetState(MovementController.MovementState.none);
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

    protected override void HandleCollisionWith(GameObject go)
    {
        switch (go.GetComponent<Collidable>().collidableType)
        {
            case CollidableType.Asteroid:
                healthController.Damage(Asteroid.DAMAGE);
                break;
            case CollidableType.Powerup:
                //print("player react to powerup");
                break;
        }
    }

    // Generally, there is no collision the player should ignore
    protected override bool ShouldIgnoreCollision(CollidableType collidableType)
    {
        return false;
    }
}
