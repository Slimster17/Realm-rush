using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSounds : MonoBehaviour
{
    [SerializeField] AudioClip constructionSound;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void ConstructSound()
    {
        _audioSource.PlayOneShot(constructionSound);
    }
}
