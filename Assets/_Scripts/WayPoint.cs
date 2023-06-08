using System;
using UnityEngine;

namespace _Scripts
{
    public class WayPoint : MonoBehaviour
    {
        [SerializeField] private Tower towerPrefab;
       
        [SerializeField] private bool isPlaceable;
        public bool IsPlaceable => isPlaceable;
        
        private void OnMouseDown()
        {
            if (isPlaceable)
            {
                Debug.Log(transform.name);
                bool isPlaced =  towerPrefab.CreateTower(towerPrefab,transform.position);
                isPlaceable = isPlaced;
            }
     
        }
    }
}
