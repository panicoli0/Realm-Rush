using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    [SerializeField] GameObject enemy;
    [SerializeField] float spawnTimer = 1;

    [SerializeField] int poolSize = 5;
    GameObject[] pool;

    void Awake()
    {
        PopulatePool();       
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemy, transform);
            pool[i].SetActive(false);
        }
    }

    void EnanleObjectInPool()
    {

        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return; //los va activando de a uno
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnanleObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
