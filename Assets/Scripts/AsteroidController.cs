using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AsteroidController : Collidable
{
    public const int DAMAGE = 25;

    private bool shouldSpawn;

    void Awake() {
        collidableType = CollidableType.Asteroid;
        shouldSpawn = false;
    }

    // Asteroids don't care what they collide with; asteroids just pool as soon as they collide
    private void OnCollisionEnter(Collision collision)
    {
        Collidable collidable;
        if (collision.gameObject.tag == "Player") {
            collidable = collision.gameObject.GetComponent<Collidable>();
            collidable.CollisionOccurred(this.collidableType);
        }

        shouldSpawn = true;
    }

    public override void CollisionOccurred(CollidableType _)
    {
        // Don't need this, we have a collider to handle
    }

    public bool GetSpawnState()
    {
        return shouldSpawn;
    }

    public void SetSpawnState(bool newSpawnState)
    {
        shouldSpawn = newSpawnState;
    }
}