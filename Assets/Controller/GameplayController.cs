using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreCounter;
    [SerializeField] private TextMeshProUGUI livesCounter;
    // Start is called before the first frame update
    public int score {private set; get;}
    public int lives {private set; get;}

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
        lives -= 1;
        Debug.Log(livesCounter);
        livesCounter.text = "Lives: " + lives.ToString();
        if (lives ==0)
        {
            //game over.
        }
    }
}
