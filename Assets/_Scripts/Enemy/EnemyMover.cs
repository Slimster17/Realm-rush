using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace _Scripts
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyMover : MonoBehaviour
    {

        [SerializeField] private List<WayPoint> path = new List<WayPoint>();
        [SerializeField] [Range(0f,5f)] private float speed = 1f;

        private Enemy _enemy;
        private void OnEnable()
        {
            
            FindPath();
            ReturnToStart();
            Debug.Log("Start here");
            StartCoroutine(FollowPath());
            Debug.Log("Finishing start");
            
        }

        private void Start()
        {
            _enemy = GetComponent<Enemy>();
        }

        private void FindPath()
        {
            path.Clear();
            
            GameObject parent = GameObject.FindGameObjectWithTag("Path");

            foreach (Transform child in parent.transform)
            {
                WayPoint wayPoint = child.GetComponent<WayPoint>();
                
                if (wayPoint != null)
                {
                    path.Add(wayPoint);
                }
                
            }
        }

        private void ReturnToStart()
        {
            transform.position = path[0].transform.position;
        }
        
        private void FinishPath()
        {
            _enemy.StealGoal();
            gameObject.SetActive(false);
        }

        private IEnumerator FollowPath()
        {
            foreach (WayPoint wayPoint in path)
            {
                Vector3 startPosition = transform.position;
                Vector3 endPosition = wayPoint.transform.position;
                float travelPercent = 0f;
                
                transform.LookAt(endPosition);

                while (travelPercent < 1f)
                {
                    travelPercent += Time.deltaTime * speed;
                    transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                    yield return new WaitForEndOfFrame();
                }
            }

            FinishPath();
        }

        
    }
}
