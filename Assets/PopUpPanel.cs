

using UnityEngine;

public class PopUpPanel : MonoBehaviour
{
    // Start is called before the first frame update
    bool isNewGame = false;
    GameObject quitPopUp;
    public GameObject newGamePopUp;
    void Start()
    {
        quitPopUp = GameObject.Find("QuitPopUp");
        newGamePopUp = GameObject.Find("NewGamePopUp");
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

    public void unHidePanelQuit()
    {
        quitPopUp.SetActive(true);
    }

    public void unHidePanelNewGame()
    {
        newGamePopUp.SetActive(true);
    }

    public void NewGame()
    {
        if (!SaveSystem.CheckLoadSaveData()) new MainMenu().PlayGame();
        if (SaveSystem.CheckLoadSaveData()) unHidePanelNewGame();
    }

    public void Quit()
    {
        //if (UnityEditor.EditorApplication.isPlaying) UnityEditor.EditorApplication.isPlaying = false;
        if (UnityEngine.Application.isPlaying) Application.Quit();
        Debug.Log("quitting game");
        Application.Quit();
    }
    void setNewGame()
    {
        isNewGame = true;
    }
    bool getNewGameStatus()
    {
        return isNewGame;
    }
    public void ConfirmNewGame()
    {
        setNewGame();
        if (getNewGameStatus())
        {
            if (SaveSystem.DeleteSaveFile())
            {
                new MainMenu().PlayGame();
            }
            else
            {
                Debug.Log("error on deleting save file");
            }
        }
    }

}
