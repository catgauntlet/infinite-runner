using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public HUDController hudController;
    public AudioController audioController;
    public RoadController roadController;

    public bool gameStarted;
    public int score;

    public void StartGame()
    {
        if (!gameStarted)
        {
            gameStarted = true;
            audioController.StartBackgroundMusic();
            roadController.StartBuildingRoad();
        }
    }

    public void EndGame()
    {
        if (PlayerPrefs.GetInt("Highscore") < score)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }

        SceneManager.LoadScene("Main");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.StartGame();
        }
    }

    public void IncreaseScore()
    {
        score++;
        hudController.UpdateScoreText();
    }
}
