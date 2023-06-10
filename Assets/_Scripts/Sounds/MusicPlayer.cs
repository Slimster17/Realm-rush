using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        int countofPlayers = FindObjectsOfType<MusicPlayer>().Length;

        if (countofPlayers > 1)
        {
            Destroy(gameObject);
           
        }
        else
        {
         DontDestroyOnLoad(gameObject);       
        }
    }
}
