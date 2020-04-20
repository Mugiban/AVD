using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button creditsButton;

    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject mainMenuPanel;
    private AudioSource source;
    [SerializeField]private AudioClip clip;
    public bool creditsOpen;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        creditsPanel.SetActive(false);
        creditsOpen = false;
        mainMenuPanel.SetActive(true);
    }

    private void OnEnable()
    {
        startButton.onClick.AddListener(OnClickStart);
        creditsButton.onClick.AddListener(OnClickCredits);
    }

    private void OnClickStart()
    {
        source.PlayOneShot(clip);
        StartCoroutine(LoadSceneCoroutine());
    }

    IEnumerator LoadSceneCoroutine()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync("CinematicScene");
    }
    private void OnClickCredits()
    {
        ToggleCreditsPanel();
    }

    public void ToggleCreditsPanel()
    {
        source.PlayOneShot(clip);
        if (creditsOpen)
        {
            creditsPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
            creditsOpen = false;
        }
        else
        {
            creditsPanel.SetActive(true);
            mainMenuPanel.SetActive(false);
            creditsOpen = true;
        }
    }
}
