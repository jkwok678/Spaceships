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

    [SerializeField] private GameObject bigAsteroid;
    [SerializeField] private GameObject smallAsteroid1;
    [SerializeField] private GameObject smallAsteroid2;
    [SerializeField] private ProgramData  myProgramData; 


    private int bigAsteroidsNo;
    private int smallAsteroidsNo;

    [SerializeField] private int levelBigAsteroidsNo;
    [SerializeField] private int levelSmallAsteroidsNo;
    // Start is called before the first frame update
    [SerializeField] private static int score;
    [SerializeField] private static int lives;
    [SerializeField] private static int level;

    [SerializeField] private float topY;

    [SerializeField] private float bottomY;

    [SerializeField] private float rightX;

    [SerializeField] private float leftX;

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
        level = 1;
        levelCounter.text = "Level: " + level.ToString();
        bigAsteroidsNo = levelBigAsteroidsNo;
        smallAsteroidsNo = levelSmallAsteroidsNo;
        AsteroidsController.ScorePointEvent += AddScore;
        PlayerController.LoseLifeEvent += MinusLife;
        Debug.Log(bigAsteroidsNo);
        Debug.Log(smallAsteroidsNo);
    }

    private void OnDisable()
    {
        AsteroidsController.ScorePointEvent -= AddScore;
        PlayerController.LoseLifeEvent -= MinusLife;
    }

    public void AddScore(int points,bool plus)
    {
        score += points;
        //Debug.Log(scoreCounter);
        scoreCounter.text = "Score: " + score.ToString();
        if (plus)
        {
            bigAsteroidsNo-=1;
            smallAsteroidsNo+=2;
        }
        else
        {
            smallAsteroidsNo-=1;
        }
        Debug.Log(bigAsteroidsNo);
        Debug.Log(smallAsteroidsNo);
        checkNewLevel();
        
    }

    public void checkNewLevel()
    {
        if (bigAsteroidsNo==0 && smallAsteroidsNo ==0)
        {
            level++;
            levelCounter.text = "Level: " + level.ToString();
            startNewLevel();
        }
    }

    public void startNewLevel()
    {
        if ((levelBigAsteroidsNo+levelSmallAsteroidsNo)%2==0)
        {
            levelBigAsteroidsNo++;
        }
        else
        {
            levelSmallAsteroidsNo++;
        }
        bigAsteroidsNo = levelBigAsteroidsNo;
        smallAsteroidsNo = levelSmallAsteroidsNo;
        for(int i = 0; i<levelBigAsteroidsNo;i++)
        {
            Vector2 location = new Vector2(Random.Range(leftX,rightX),Random.Range(bottomY,topY));
            Instantiate(bigAsteroid, location, Quaternion.identity);
            
        }
        for(int i = 0; i<levelSmallAsteroidsNo;i++)
        {
            if (i%2 == 0)
            {
                Vector2 location = new Vector2(Random.Range(leftX,rightX),Random.Range(bottomY,topY));
                Instantiate(smallAsteroid1, location, Quaternion.identity);
            }
            else
            {
                Vector2 location = new Vector2(Random.Range(leftX,rightX),Random.Range(bottomY,topY));
                Instantiate(smallAsteroid2, location, Quaternion.identity);
            }
        }
    }

    public void MinusLife()
    {
        if (lives > 1)
        {
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
