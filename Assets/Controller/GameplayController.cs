using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreCounter;
    // Start is called before the first frame update
    public int score {private set; get;}

    private void OnEnable()
    {
        score = 0;
        
        AsteroidsController.ScorePointEvent += AddScore;
    }

    private void OnDisable()
    {
        AsteroidsController.ScorePointEvent -= AddScore;
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log(scoreCounter);
        scoreCounter.text = "Score: " + score.ToString();
    }
}
