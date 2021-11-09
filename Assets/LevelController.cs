using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelController : MonoBehaviour
{
    int sceneLength;
    float width;
    string[] scenePath;
    public GameObject LevelButtonPrefab;
    GameObject buttonContainer;
    // Start is called before the first frame update
    void Start()
    {
        buttonContainer = this.transform.gameObject;
        sceneLength = SceneManager.sceneCountInBuildSettings - 3;
        scenePath = new string[sceneLength];
        scenePath = AssignScenePath(scenePath, sceneLength);


        width = this.GetComponent<RectTransform>().rect.width;

        instantiateLevelButton(sceneLength);
        Debug.Log("width "+width);
    }

    string[] AssignScenePath(string[] scenes, int len)
    {
        for(int i = 0; i < len; i++)
        {
            scenes[i] = SceneUtility.GetScenePathByBuildIndex(i);
        }

        return scenes;
    }

    void instantiateLevelButton(int len)
    {
        GameObject[] buttons = new GameObject[len];
        for(int i = 0; i < len; i++)
        {
            
                buttons[i] = Instantiate(LevelButtonPrefab);
                buttons[i].transform.SetParent(this.transform, false);
                Vector3 curPos = buttons[i].GetComponent<RectTransform>().anchoredPosition;
                Vector3 newPos = new Vector3(curPos.x * (i * 2) + curPos.x, curPos.y, curPos.z);

                float rightEdge = newPos.x + 50;

                buttons[i].GetComponent<RectTransform>().anchoredPosition = newPos;
                buttons[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Level "+(i+1);

                int _index = i;
                buttons[i].GetComponent<Button>().onClick.AddListener(() =>
                {
                    Debug.Log(_index);
                    loadScene(_index);
                });
                //setText(buttons[i], i);
        }
    }

    void setText(GameObject btn, int index)
    {
        btn.GetComponentInChildren<TextMesh>().text = "Level " + index; 
    }

    void loadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    // Update is called once per frame
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 3);
    }
}
