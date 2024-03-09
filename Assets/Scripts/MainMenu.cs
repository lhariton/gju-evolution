using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnPlayButton()
    {
        SceneManager.LoadSceneAsync("Level1");
    }
    public void OnCreditsButton()
    {
        SceneManager.LoadSceneAsync("Credits");
    }
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
