using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* My understanding of the InputAction.canceled property was false: it is only called once
* So, ReplenishFuel() is only called once
* Let's instead make an enum State for Replenishing or Depleting, and based on that call their respecitve functions
*/
public class FuelController : MonoBehaviour
{
    [SerializeField] private float depletionRate;
    [SerializeField] private float replenishRate;

    [SerializeField] private float fuel;

    void Awake()
    {
        fuel = 100f;
    }

    private float GetFuel()
    {
        return fuel;
    }

    public void DepleteFuel()
    {
        if (Mathf.Approximately(fuel, 0f)) { return; }
        fuel -= depletionRate;
    }

    public void ReplenishFuel()
    {
        if (Mathf.Approximately(fuel, 100f)) { return; }
        print("replenishing!");
        fuel += replenishRate;
    }
}
