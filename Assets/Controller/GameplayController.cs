using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameplayController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreCounter;
    [SerializeField] private TextMeshProUGUI livesCounter;
    [SerializeField] private TextMeshProUGUI levelCounter;
    [SerializeField] private GameObject gameOverPanel;
    // Start is called before the first frame update
    [SerializeField] private static int score;
    [SerializeField] private static int lives;

    public static int GetScore()
    {
        return score;
    }

    public static int GetLives()
    {
        return lives;
    }
    private void OnEnable()
    {
        score = 0;
        lives = 3;
        AsteroidsController.ScorePointEvent += AddScore;
        PlayerController.LoseLifeEvent += MinusLife;
    }

    private void OnDisable()
    {
        AsteroidsController.ScorePointEvent -= AddScore;
        PlayerController.LoseLifeEvent -= MinusLife;
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log(scoreCounter);
        scoreCounter.text = "Score: " + score.ToString();
    }

    public void MinusLife()
    {
        if (lives > 0)
        {
            //game over.
            lives-=1;
        }
        else
        {
            GameOver();
        }
        livesCounter.text = "Lives: " + lives.ToString();
        
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
