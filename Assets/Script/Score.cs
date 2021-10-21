using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI textScore;
    int score;
    int currentScore;
    int totalScore;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        currentScore = score;
        
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        totalScore = coins.Length;

        textScore.text = $"{score.ToString()}/{totalScore.ToString()}";
    }

    // Update is called once per frame
    void Update()
    {
        if(score != currentScore)
        {
            currentScore = score;
            textScore.text = $"{score.ToString()}/{totalScore.ToString()}";
        }
        if(score == totalScore)
        {
            Finish();
        }
    }

    public void UpdateScore()
    {
        score++;
    }

    void Finish()
    {
        Debug.Log("all coins already collected!");
    }
}
