using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private int score = 0;


    void Start()
    {
        UpdateScoreText();
    }


    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }


    public void DecreaseScore(int amount)
    {
        score -= amount;
        UpdateScoreText();
    }


    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }


    public int GetScore()
    {
        return score;
    }
}
