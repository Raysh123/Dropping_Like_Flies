using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool sharedInstance;
    public List<GameObject> pooledStone;
    public List<GameObject> pooledLeaf;
    public List<GameObject> pooledDrops;
    public List<GameObject> pooledFoods;
    public GameObject stoneToPool;
    public GameObject leafToPool;
    public GameObject dropsToPool;
    public GameObject foodToPool;
    public int amountToPool;

    private void Awake()
    {
        sharedInstance = this;
    }
    void Start()
    {
        pooledStone = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(stoneToPool);
            tmp.SetActive(false);
            pooledStone.Add(tmp);
        }

        pooledFoods = new List<GameObject>();
        GameObject food;
        for(int i = 0; i < amountToPool; i++)
        {
            food = Instantiate(foodToPool);
            food.SetActive(false);
            pooledFoods.Add(food);
        }

        pooledLeaf = new List<GameObject>();
        GameObject leaf;
        for(int i = 0; i < amountToPool; i++)
        {
            leaf = Instantiate(leafToPool);
            leaf.SetActive(false);
            pooledLeaf.Add(leaf);
        }

        pooledDrops = new List<GameObject>();
        GameObject drop;
        for(int i = 0; i < amountToPool; i++)
        {
            drop = Instantiate(dropsToPool);
            drop.SetActive(false);
            pooledDrops.Add(drop);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            if (!pooledStone[i].activeInHierarchy)
            {
                return pooledStone[i];
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

    public GameObject GetPooledLeaf()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledFoods[i].activeInHierarchy)
            {
                return pooledLeaf[i];
            }
        }
        return null;
    }
    public GameObject GetPooledDrops()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledFoods[i].activeInHierarchy)
            {
                return pooledDrops[i];
            }
        }
        return null;
    }
}
