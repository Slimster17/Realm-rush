using System;
using UnityEngine;

namespace _Scripts
{
    
    [RequireComponent(typeof(Enemy))]
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int maxHitPoints = 5;
        
        [Tooltip("Adds amount to maxHitPoints when enemy dies.")]
        [SerializeField] private int difficultyRamp = 1;

        private int _currentHitPoints = 0;

        private Enemy _enemy;
    

        void OnEnable()
        {
            _currentHitPoints = maxHitPoints;
        }

        private void Start()
        {
            _enemy = GetComponent<Enemy>();
        }

        private void OnParticleCollision(GameObject other)
        {
            // Debug.Log($"Collision with {other.name}");

            ProcessHit();
        }

        private void ProcessHit()
        {
            if (!(_currentHitPoints <= 0))
            {
                _currentHitPoints -= 1;
            }
            else
            {
                gameObject.SetActive(false);
                maxHitPoints += difficultyRamp;
                _enemy.RewardGoal();
            }
        }
    }
}
