using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public int highScore;
    public Text result;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (gameOverScreen.activeSelf)
        {
            return;
        }
        else
        {
            playerScore = playerScore + scoreToAdd;
            scoreText.text = playerScore.ToString();
        }

        // Using Player Prefs for Highest Score
        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("highScore", highScore);
            PlayerPrefs.Save();
        }
        updateHighest();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        updateHighest();
    }

    private void updateHighest()
    {
        if (highScore.ToString() != null){
            result.text = "High Score: " + highScore.ToString();
        }
    }
}
