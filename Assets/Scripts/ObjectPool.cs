using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool sharedInstance;
    public List<GameObject> pooledObjects;
    public List<GameObject> pooledFoods;
    public GameObject objectToPool;
    public GameObject foodToPool;
    public int amountToPool;

    private void Awake()
    {
        sharedInstance = this;
    }
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }

        pooledFoods = new List<GameObject>();
        GameObject food;
        for(int i = 0; i < amountToPool; i++)
        {
            food = Instantiate(foodToPool);
            food.SetActive(false);
            pooledFoods.Add(food);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    public GameObject GetPooledFoods()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            if(!pooledFoods[i].activeInHierarchy)
            {
                return pooledFoods[i];
            }
        }
        return null;
    }
}
