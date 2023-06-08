using System;
using UnityEngine;

namespace _Scripts
{
    public class TargetLocator : MonoBehaviour
    {
        [SerializeField] Transform weapon;
        [SerializeField] private float range = 15f;
        [SerializeField] private ParticleSystem projectileParticles;
        
        private Transform _target;
        
        void Update()
        {
            FindClosestTarget();
            AimWeapon();
        }

        private void FindClosestTarget()
        {
            Enemy[] enemies = FindObjectsOfType<Enemy>();
            Transform closestTarget = null;
            float maxDistance = Mathf.Infinity;

            foreach (Enemy enemy in enemies)
            {
                float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

                if (targetDistance < maxDistance)
                {
                    closestTarget = enemy.transform;
                    maxDistance = targetDistance;
                }
            }

            _target = closestTarget;
        }

        private void AimWeapon()
        {
            float targetDistance = Vector3.Distance(transform.position, _target.position);

            weapon.LookAt(_target);
            
            if (targetDistance <= range)
            {
                Attack(true);
            
            }
            else
            {
                Attack(false);
            }
          
        }

        private void Attack(bool isActive)
        {
            var emissionModule = projectileParticles.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}
