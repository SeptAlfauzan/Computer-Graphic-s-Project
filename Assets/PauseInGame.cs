using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseInGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvasUI;
    bool isActive;
    void Start()
    {
        resumeGame();
        hide();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !this.isActive) {
            unHide();
            pauseGame();
        };
    }

    void show(bool status)
    {
        canvasUI.SetActive(status);
    }

    void hide()
    {
        this.isActive = false;
        show(false);
    }
    void unHide()
    {
        this.isActive = true;
        show(true);
    }

    void pauseGame()
    {
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        if(this.isActive) hide(); 
        Time.timeScale = 1;
    }

    public void backtoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
