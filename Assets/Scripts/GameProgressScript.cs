using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameProgressScript : MonoBehaviour
{
    public AudioSource audioSource;
    private SpaceShipScript spaceShipScript;

    private Timer timer;


    void Start()
    {
        spaceShipScript = FindAnyObjectByType<SpaceShipScript>();
        timer = GetComponent<Timer>();
    }


    public void GameOver()
    {
        audioSource.Stop();
        spaceShipScript.ExplosiveYourSelf();
        timer.StartTimer(3f, RenderGameOver);
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
