using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameProgressScript : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject pausePanel;

    private SpaceShipScript spaceShipScript;
    private ScoreScript scoreScript;

    private Timer timer;

    private bool onPause = false;


    void Start()
    {
        pausePanel.SetActive(false);

        spaceShipScript = FindAnyObjectByType<SpaceShipScript>();
        scoreScript = FindAnyObjectByType<ScoreScript>();
        timer = GetComponent<Timer>();
    }

    private void Update()
    {
        PauseController();
    }


    private void PauseController()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!onPause)
            {
                PauseGame();
            }
            else
            {
                ContinueGame();
            }
        }
    }


    public void PauseGame()
    {
        onPause = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ContinueGame()
    {
        onPause = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }


    public void GameOver()
    {
        audioSource.Stop();
        spaceShipScript.ExplosiveYourSelf();
        timer.StartTimer(3f, RenderGameOver);

        PlayerPrefs.SetInt("Score", scoreScript.GetScore());
        PlayerPrefs.Save();
    }


    public void RenderGameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }


    public void ReStartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
