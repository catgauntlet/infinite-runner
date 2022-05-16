
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public GameManager gameManager;
    public Text scoreText;
    public Text highScoreText;

    private void Start()
    {
        highScoreText.text = "High score: " + PlayerPrefs.GetInt("Highscore", 0);
    }

    public void UpdateScoreText()
    {
        scoreText.text = gameManager.score.ToString();
    }
}
