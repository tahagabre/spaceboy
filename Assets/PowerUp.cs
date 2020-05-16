using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Collidable
{
    void Awake()
    {
        collidableType = CollidableType.Powerup;
    }

    protected override void HandleCollisionWith(GameObject other)
    {
        base.HandleCollisionWith(other);
        print(gameObject.name + ": giving player buff!");
    }

    protected override bool ShouldIgnoreCollision(CollidableType collidableType)
    {
        if (collidableType == CollidableType.Asteroid || collidableType == CollidableType.Powerup) { return true; }
        return false;
    }
}
