using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turret
{
    public class TurretSpawner : MonoBehaviour
{
    public GameObject turretPrefab;
    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(turretPrefab, hitInfo.point, Quaternion.identity);
            }
        }
    }
}

}