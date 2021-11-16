
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    bool isdeath = false;
    public GameObject player;
    public GameObject panel;
    void Start()
    {
        show(false);
    }
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null) show(true);
    }
    // Update is called once per frame
    void show(bool status)
    {
        panel.SetActive(status);
    }
    public void reloadScene()
    {
        show(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void backtoMainMenu()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 3);
    }
}
