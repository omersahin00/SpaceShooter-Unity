using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreTextScript : MonoBehaviour
{
    private TextMeshProUGUI highScoreText;
    private int score;
    private int? highScore;

    void Start()
    {
        highScoreText = GetComponent<TextMeshProUGUI>();

        score = PlayerPrefs.GetInt("Score");

        highScore = PlayerPrefs.GetInt("HighScore");

        print(highScore);
        print(score);

        if (highScore == null || highScore < score)
        {
            
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();

            highScoreText.text = "New High Score: " + score.ToString();
        }
        else
        {
            highScoreText.text = "High Score: " + highScore.ToString();
        }

    }
}
