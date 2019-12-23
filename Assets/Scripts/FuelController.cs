using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour
{
    public const float FUEL_MAX = 100f;
    public const float FUEL_MIN = 0f;

    [HideInInspector] public enum FuelState { depleting, replenishing, empty };
    private FuelState fuelState;

    [SerializeField] private float depletionRate;   // How fast player loses fuel
    [SerializeField] private float replenishRate;   // How fast player regains fuel
    [SerializeField] private float fuel;    // Fuel amount
    [SerializeField] private float fuelRestorationTime; // After going empty, how much time the player must wait to go back to full

    void Awake()
    {
        fuelState = FuelState.replenishing;
        fuel = FUEL_MAX;
    }

    private void Update()
    {
        if (Mathf.Approximately(fuel, FUEL_MIN)) { fuelState = FuelState.empty; }
        switch (fuelState)
        {
            case FuelState.depleting:
                DepleteFuel();
                break;
            case FuelState.replenishing:
                ReplenishFuel();
                break;
            case FuelState.empty:
                FuelExhausted();
                break;
        }
    }

    public void SetFuelState(FuelState newFuelState)
    {
        fuelState = newFuelState;
    }

    public FuelState GetFuelState()
    {
        return fuelState;
    }

    public float GetFuel()
    {
        return fuel;
    }

    private void DepleteFuel()
    {
        if (Mathf.Approximately(fuel, FUEL_MIN)) { return; }
        fuel -= depletionRate;
    }

    private void ReplenishFuel()
    {
        if ((fuel + replenishRate) > FUEL_MAX) { return; }
        fuel += replenishRate;
    }

    private void FuelExhausted()
    {
        print("empty");
        // Damage Player Here
        StartCoroutine("RestoreFuel");
    }

    private IEnumerator RestoreFuel()
    {
        yield return new WaitForSeconds(fuelRestorationTime);
        fuel = FUEL_MAX;
        fuelState = FuelState.replenishing;
    }
}
