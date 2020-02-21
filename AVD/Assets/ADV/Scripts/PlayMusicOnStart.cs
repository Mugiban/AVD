using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOnStart : MonoBehaviour
{
    private AudioSource source;
    [SerializeField] private AudioClip clip;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void Start()
    {
        source.clip = clip;
        source.Play();
    }
}
