using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    [SerializeField] private MainMenu mainMenu;

    private Button backButton;
    private void Awake()
    {
        backButton = GetComponent<Button>();
        backButton.onClick.AddListener(OnClickBack);
    }

    private void OnClickBack()
    {
        mainMenu.ToggleCreditsPanel();
    }
}
