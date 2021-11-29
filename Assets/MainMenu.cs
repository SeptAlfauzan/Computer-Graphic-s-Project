using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = 1;
        Debug.Log(Application.dataPath);
        if (!SaveSystem.CheckLoadSaveData()) DisableLoadButton(true);
    }

    void DisableLoadButton(bool status)
    {
        if (status)
        {
            GameObject.Find("LoadButton").GetComponent<Button>().interactable = false;
            GameObject.Find("LoadText").GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 101);
        }
        else
        {
            GameObject.Find("LoadButton").GetComponent<Button>().interactable = true;
            GameObject.Find("LoadText").GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);
        }
    }

    public void PlayGame()
    {
        //Time.timeScale = 1;
        // Load Level Controller Scene
        SceneManager.LoadScene(2);
    }

    public void LoadGame()
    {
        PlayGame();
    }

    

    public void Credit()
    {
        SceneManager.LoadScene(1);
    }
}
