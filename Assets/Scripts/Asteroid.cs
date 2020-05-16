using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Collidable
{
    public const int DAMAGE = 25;

    void Awake() {
        collidableType = CollidableType.Asteroid;
    }

    protected override void HandleCollisionWith(GameObject other)
    {
        base.HandleCollisionWith(other);
        //print(gameObject.name + ": handling collision with death animation!");
    }

    protected override bool ShouldIgnoreCollision(CollidableType collidableType)
    {
        if (collidableType == CollidableType.Asteroid || collidableType == CollidableType.Powerup) { return true; }
        return false;
    }
}