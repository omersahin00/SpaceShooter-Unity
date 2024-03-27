using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score;


    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();

        score = PlayerPrefs.GetInt("Score");

        scoreText.text = "Score: " + score.ToString();
    }

}
