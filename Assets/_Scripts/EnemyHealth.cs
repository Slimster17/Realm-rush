using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHitPoints = 5;

    [SerializeField] private int currentHitPoints = 0;

    private Enemy _enemy;
    

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
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
        if (!(currentHitPoints <= 0))
        {
            currentHitPoints -= 1;
        }
        else
        {
            gameObject.SetActive(false);
            _enemy.RewardGoal();
        }
    }
}
