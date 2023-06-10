using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace _Scripts
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private int cost = 75;
        [SerializeField] private float buildDelay = 1f;

        private TowerSounds _towerSounds;
        private void Start()
        {
            _towerSounds = GetComponent<TowerSounds>();
            StartCoroutine(Build());
        }

        private IEnumerator Build()
        {
            _towerSounds.ConstructSound();
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
                foreach (Transform grandchild in child)
                {
                    grandchild.gameObject.SetActive(false);
                }
            }
            
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
                yield return new WaitForSeconds(buildDelay);
                foreach (Transform grandchild in child)
                {
                    grandchild.gameObject.SetActive(true);
                }
            }
        }

        public bool CreateTower(Tower tower, Vector3 position)
        {
            Bank bank = FindObjectOfType<Bank>();
            

            if (bank == null)
            {
                return false;
            }

            if (bank.CurrentBalance >= cost)
            {
                
                Instantiate(tower, position, Quaternion.identity);
                bank.WithDraw(cost);
                return true;
                
            }
            return false;
        }
    }
}
