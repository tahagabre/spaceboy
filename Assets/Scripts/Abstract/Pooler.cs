using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// Reusable class for maintaing lifecycle of statically allocated prefabs
// i.e Asteroids, Power Ups, Mobs
public abstract class Pooler : MonoBehaviour
{
    protected Queue<GameObject> pooledObjects = new Queue<GameObject>();
    
    [SerializeField] private GameObject prefabToPool;
    [SerializeField] private int amountOfObjects;

    private float timer = 0;
    [SerializeField] private float releaseThreshold;

    [SerializeField] private float moveDuration;
    [SerializeField] private Ease ease;

    [SerializeField] private SpaceBoyController player;
    [SerializeField] private float distance;
    private Vector3 newPosition;
    
    private void Awake()
    {
        InstantiateObjects();
    }

    private void OnDisable()
    {
        foreach (GameObject go in pooledObjects)
        {
            if (!go?.GetComponent<Collidable>())
            {
                go.GetComponent<Collidable>().DidCollide -= Collect;
            }
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > releaseThreshold)
        {
            Release();
            timer = 0;
        }

        // Move the pooler horizontally
        if (player) {
            newPosition = CalculateNewPosition(player.transform.position);
        }
        transform.DOMove(newPosition, moveDuration).SetEase(ease);
    }

    protected void InstantiateObjects()
    {
        GameObject prefab;
        foreach(int i in System.Linq.Enumerable.Range(1, amountOfObjects))
        {
            prefab = Instantiate(prefabToPool, transform.position, Quaternion.identity);
            pooledObjects.Enqueue(prefab);
            prefab.GetComponent<Collidable>().DidCollide += Collect;
        }
        //print(pooledObjects.Count);
    }

    private Vector3 CalculateNewPosition(Vector3 playerPosition)
    {
        float delta = Random.Range(-distance, distance);
        return new Vector3(playerPosition.x + delta, transform.position.y, playerPosition.z);
    }

    protected abstract void Collect(GameObject gameObj);

    protected abstract void Release();
}
