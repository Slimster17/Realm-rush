using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts
{
    public class ObjectPool : MonoBehaviour
    {
       [SerializeField] private GameObject enemyPrefab;
       [SerializeField] private float spawnTimer = 1f;
       [SerializeField] private int poolSize = 5;

       private GameObject[] pool;

       private void Awake()
       {
           PopulatePool();
       }
       
       void Start()
        {
            StartCoroutine(SpawnEnemies());
        }
       
       private void PopulatePool()
       {
           pool = new GameObject[poolSize];

           for (int i = 0; i < pool.Length; i++)
           {
               pool[i] = Instantiate(enemyPrefab, transform);
               pool[i].SetActive(false);
           }
       }
       
       private void EnableObjectsInPool()
       {
           for (int i = 0; i < pool.Length; i++)
           {
               if (pool[i].activeInHierarchy == false)
               {
                   pool[i].SetActive(true);
                   return;
               }
              
           }
       }
        IEnumerator SpawnEnemies()
        {
            while (true)
            {
                EnableObjectsInPool();
                // Instantiate(enemyPrefab, transform);
                yield return new WaitForSeconds(spawnTimer);
            }
        
        }

        
    }
}
