using System;
using UnityEngine;

namespace _Scripts
{
    public class TargetLocator : MonoBehaviour
    {
        [SerializeField] Transform weapon; 
        private Transform _target;


        private void Start()
        {
            _target = FindObjectOfType<EnemyMover>().transform;
        }

        void Update()
        {
            AimWeapon();
        }

        private void AimWeapon()
        {
            weapon.LookAt(_target);
        }
    }
}
