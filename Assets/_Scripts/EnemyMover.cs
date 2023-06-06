using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class EnemyMover : MonoBehaviour
    {

        [SerializeField] private List<WayPoint> path = new List<WayPoint>();
        [SerializeField] private float waitTime = 1f;

        private void Start()
        {
            Debug.Log("Start here");
            StartCoroutine(FollowPath());
            Debug.Log("Finishing start");
        }

        private IEnumerator FollowPath()
        {
            foreach (WayPoint wayPoint in path)
            {
                this.transform.position = wayPoint.transform.position;
                yield return new WaitForSeconds(waitTime);
            }
            
        }
        

    }
}
