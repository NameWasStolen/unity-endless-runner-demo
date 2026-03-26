using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public GameObject gameOverScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        updateScoreText();
    }

    public void addScore(int addValue = 1)
    {
        score += addValue;
        updateScoreText();
    }

    private void updateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
