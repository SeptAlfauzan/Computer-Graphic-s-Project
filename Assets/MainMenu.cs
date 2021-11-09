using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        //Time.timeScale = 1;
        // Load Level Controller Scene
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }
    public void Credit()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 2);
    }
}
