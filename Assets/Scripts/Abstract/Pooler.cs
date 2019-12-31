using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reusable class for maintaing lifecycle of statically allocated prefabs
// i.e Asteroids, Power Ups, Mobs
public abstract class Pooler : MonoBehaviour
{
    /*
     * Requirements:
     * Have a queue of objects
     * Hold a GameObject prefab property
     * Create the objects
     * Spawn objects
     * _____________________________
     * 
     * Collect inactive objects, send back to queue via notification NOT IMPLEMENTED
     * Respawn items NOT IMPLEMENTED
     */

    static Queue<GameObject> pooledObjects
    {
        get
        {
            return new Queue<GameObject>();
        }
    }

    [SerializeField] private GameObject prefabToPool;
    [SerializeField] private int amountOfObjects;

    private void Awake()
    {
        InstantiateObjects();
    }

    private void InstantiateObjects()
    {
        foreach(int i in System.Linq.Enumerable.Range(1, amountOfObjects))
        {
            pooledObjects.Enqueue(Instantiate(prefabToPool));
        }
    }

    static void SendToBack(GameObject gameObj)
    {
        pooledObjects.Enqueue(gameObj);
    }

    private void SpawnObject(Vector3 position)
    {
        GameObject go = pooledObjects.Dequeue();
        go.transform.position = position;
    }

}
