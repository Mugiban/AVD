using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turret
{
    public class Turret : MonoBehaviour
    {
        private Animator animator;
        public TurretShot projectile;
        public Transform[] turretShotPositionsLeft;
        public Transform[] turretShotPositionsRight;
        public Transform topObject;

        private bool canShoot;
        private float refireTime = 0.3f;
        private float refireTimer = 0;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            animator.SetBool("shooting", true);
        }

        private void Start()
        {
            refireTimer = 0;
            StartCoroutine(StopTurret());
        }

        public void StartShooting()
        {
            canShoot = true;
        }

        private IEnumerator StopTurret()
        {
            
            yield return new WaitForSeconds(10f);
            canShoot = false;
            animator.SetBool("shooting", false);
            Destroy(gameObject, 0.75f);
        }

        private bool hasShotLeft;
        private void Shot()
        {
            if (!hasShotLeft)
            {
                foreach (var point in turretShotPositionsLeft)
                {
                    Instantiate(projectile, point.position, topObject.rotation);
                }

                hasShotLeft = true;
            }
            else
            {
                foreach (var point in turretShotPositionsRight)
                {
                    Instantiate(projectile, point.position, topObject.rotation);
                }

                hasShotLeft = false;
            }
        }

        private void Update()
        {
            refireTimer += Time.deltaTime;
            if (refireTimer >= refireTime && canShoot)
            {
                refireTimer = 0;
                Shot();
            }
        }
    }
}
