using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject scoreText;

    // Update is called once per frame
    private void Start()
    {
        scoreText = GameObject.Find("ScoreText");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Disappear();
            scoreText.GetComponent<Score>().UpdateScore();
        }
    }
    void Disappear()
    {
        Debug.Log("collide with player");
    }
}
