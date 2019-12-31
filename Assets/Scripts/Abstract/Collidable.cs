using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class allows communication between rigidbodies in a noninvasive way
 * i.e rigidbodies getting their colliders components and calling the appropriate methods directly
 * Instead, we choose to abstract all rigidbody calls by simply notifying the other collider that the collision had occurred and what entity they collided with.
 * From there, each collider will internally decide how to react, without the counterpart collider knowing a thing
 */
public abstract class Collidable : MonoBehaviour
{
    public enum CollidableType { Asteroid, Powerup, Mob, Boss, Player };
    protected CollidableType collidableType;
    public abstract void CollisionOccurred(CollidableType type);
}