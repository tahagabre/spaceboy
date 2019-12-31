using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : Collidable
{
    public const int DAMAGE = 25;
    private bool active; // In field of play

    void Awake() {
        collidableType = CollidableType.Asteroid;
        active = false;
    }

    // Asteroids don't care what they collide with; asteroids just pool as soon as they collide
    private void OnCollisionEnter(Collision collision)
    {
        Collidable collidable;
        if (collision.gameObject.tag == "Player") {
            collidable = collision.gameObject.GetComponent<Collidable>();
            collidable.CollisionOccurred(this.collidableType);
        }

        active = true;
    }

    // Code Smell, violates Interface Seperation Principle
    public override void CollisionOccurred(CollidableType _)
    {
        // Don't need this, we have a collider to handle
    }

    public bool IsActive()
    {
        return active;
    }

    public void SetActiveState(bool newActiveState)
    {
        active = newActiveState;
    }

    // Not used internally
    public void Spawn(Vector3 position)
    {
        transform.position = position;
    }
}