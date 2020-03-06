using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsUI : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    [SerializeField] private int pointsCounter;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        pointsCounter = 0;
        textMesh.text = pointsCounter + "";

    }

    private void OnEnable()
    {
        PickUp.OnPickUp += UpdateUI;
    }

    private void OnDisable()
    {
        PickUp.OnPickUp -= UpdateUI;
    }

    private void UpdateUI(int points)
    {
        pointsCounter += points;
        textMesh.text = pointsCounter + "";
    }
}
