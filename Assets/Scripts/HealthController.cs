using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private int health;

    void Awake()
    {
        health = 100;
    }

    public void DamagePlayer(int damage) {
        health -= damage;
    }
}
