using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerShooter2D : MonoBehaviour
{
    public Projectile projectile;

    private PlayerController2D playerController;
    private AudioSource source;
    public Transform gunMuzzle;
    private void Awake()
    {
        playerController = GetComponent<PlayerController2D>();
        source = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var bullet = Instantiate(projectile, gunMuzzle.position, Quaternion.identity);
            bullet.SetDirection(playerController.FacingRight);
            source.pitch = Random.Range(0.9f, 1.1f);
            source.Play();
        }
    }
}