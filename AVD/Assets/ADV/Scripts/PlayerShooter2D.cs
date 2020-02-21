using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter2D : MonoBehaviour
{
    public Projectile projectile;

    private PlayerController2D playerController;
    public Transform gunMuzzle;
    private void Awake()
    {
        playerController = GetComponent<PlayerController2D>();
    }


    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var bullet = Instantiate(projectile, gunMuzzle.position, Quaternion.identity);
            bullet.SetDirection(playerController.FacingRight);
        }
    }
}