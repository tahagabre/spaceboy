﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPooler : Pooler
{
    protected override void Collect(GameObject gameObject)
    {
        print(this.gameObject.name + " collected");
        pooledObjects.Enqueue(gameObject);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.transform.position = transform.position;
    }

    protected override void Release()
    {
        if (pooledObjects.Peek() == null) { return; }
        GameObject powerUp = pooledObjects.Dequeue();
        powerUp.GetComponent<Rigidbody>().isKinematic = false;
    }
}