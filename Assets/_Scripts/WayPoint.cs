using System;
using UnityEngine;

namespace _Scripts
{
    public class WayPoint : MonoBehaviour
    {
        [SerializeField] private GameObject towerPrefab;
       
        [SerializeField] private bool isPlaceable;
        public bool IsPlaceable => isPlaceable;
        
        private void OnMouseDown()
        {
            if (isPlaceable)
            {
                Debug.Log(transform.name);
                
                Instantiate(towerPrefab, transform.position, Quaternion.identity);
                isPlaceable = false;
            }
     
        }
    }
}
