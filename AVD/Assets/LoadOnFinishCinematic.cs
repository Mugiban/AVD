using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnFinishCinematic : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadSceneAsync("PlayableScene");
    }
}
