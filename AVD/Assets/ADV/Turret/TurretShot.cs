using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Turret
{
    public class TurretShot : MonoBehaviour
    {
        public float moveSpeed = 10f;
        
        private void Update()
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

}
