using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void LoadSunnyScene()
    {
        SceneManager.LoadSceneAsync("SunnyLand");
    }
}
