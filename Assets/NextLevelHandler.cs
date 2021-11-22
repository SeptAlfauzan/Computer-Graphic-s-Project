using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevelHandler : MonoBehaviour
{
    GameObject buttonNextLvl;
    int curSceneIndex;
    int lastLvlSceneIndexl;
    // Start is called before the first frame update
   
    void Awake()
    {
        CheckLastLevel();
               
    }
    private void Start()
    {
        curSceneIndex = SceneManager.GetActiveScene().buildIndex;
        lastLvlSceneIndexl = SceneManager.sceneCountInBuildSettings - 1;
        
        
        if (curSceneIndex != lastLvlSceneIndexl) GameObject.Destroy(GameObject.Find("LastText"));
        ShowCanvas(false);
    }
    void CheckLastLevel()
    {
        curSceneIndex = SceneManager.GetActiveScene().buildIndex;
        lastLvlSceneIndexl = SceneManager.sceneCountInBuildSettings - 1;
        if (curSceneIndex == lastLvlSceneIndexl) GameObject.Destroy(GameObject.Find("BtnNextLevel")); //destroy next level button if the current level is last level
    }

    public void ShowCanvas(bool status)
    {
        this.gameObject.SetActive(status);
    }

    public void NextLevel()
    {
        UnlockLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ShowCanvas(false);
    }
    public void backtoMainMenu()
    {
        UnlockLevel();   
        SceneManager.LoadScene(0);
    }

    void UnlockLevel()
    {
        PlayerSaveData loadData = SaveSystem.LoadSaveData();
        if (loadData == null) loadData = new PlayerSaveData(0, "");
        curSceneIndex = SceneManager.GetActiveScene().buildIndex;
        lastLvlSceneIndexl = SceneManager.sceneCountInBuildSettings - 1;
        //save level if player unlock higher lvel than load data
        if (SceneManager.GetActiveScene().buildIndex - 3 >= loadData.level && curSceneIndex < lastLvlSceneIndexl) SaveData(SceneManager.GetActiveScene().buildIndex - 2);
    }

    void SaveData(int level)
    {
        Debug.Log("saving new data");
        string name = System.DateTime.Now.ToString();
        SaveSystem.SaveData(level, name);
    }
}
