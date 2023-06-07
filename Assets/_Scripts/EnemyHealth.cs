using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHitPoints = 5;

    [SerializeField] private int currentHitPoints = 0;
    
    
    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log($"Collision with {other.name}");
        if (!(currentHitPoints <= 0))
        {
            currentHitPoints -= 1;
        }
        else
        {
            gameObject.SetActive(false);
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
