using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreCounter;
    [SerializeField] private TextMeshProUGUI livesCounter;
    // Start is called before the first frame update
    public static int score {private set; get;}
    public static int lives {private set; get;}
    [SerializeField] private GameObject gameOverPanel;

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
}
