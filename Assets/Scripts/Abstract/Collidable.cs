using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class allows communication between rigidbodies in a noninvasive way
 * i.e rigidbodies getting their colliders components and calling the appropriate methods directly
 * Instead, we choose to abstract all rigidbody calls by simply notifying the other collider that the collision had occurred and what entity they collided with.
 * From there, each collider will internally decide how to react, without the counterpart collider knowing a thing
 */
public class Collidable : MonoBehaviour
{
    public enum CollidableType { Asteroid, Powerup, Mob, Boss, Player, Equipment, Collector };
    public CollidableType collidableType;

    public delegate void OnCollision(GameObject go);
    public event OnCollision DidCollide;

    void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if ( other == null) { return; }
        CollisionOccurred(other);
    }

    public virtual void CollisionOccurred(GameObject other) {
        if (ShouldIgnoreCollision(other.GetComponent<Collidable>().collidableType)) { /*print(this.gameObject.name + " is ignoring collision with " + other.name);*/  return; }

        if (DidCollide != null) {
            // I collided, so collect me!
            DidCollide(gameObject);
        }

        // Based on what the other collider is, react appropriately 
        HandleCollisionWith(other);
    }

    protected virtual void HandleCollisionWith(GameObject other) { }
    protected virtual bool ShouldIgnoreCollision(CollidableType collidableType) { return true; }
}