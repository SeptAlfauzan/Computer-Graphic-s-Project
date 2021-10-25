using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        hidePanel();
    }
    void showPanel(bool status)
    {
        this.gameObject.SetActive(status);//hide panel when game started
    }
     public void hidePanel()
    {
        showPanel(false);
    }

    public void unHidePanel()
    {
        showPanel(true);
    }

    public void Quit()
    {
        if (UnityEditor.EditorApplication.isPlaying) UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("quitting game");
        Application.Quit();
    }
}
