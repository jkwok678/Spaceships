using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreCounter;
    [SerializeField] private TextMeshProUGUI livesCounter;
    [SerializeField] private TextMeshProUGUI tutorial;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI tutorialEndText;

    [SerializeField] private GameObject bigAsteroid;
    [SerializeField] private GameObject smallAsteroid1;
    [SerializeField] private GameObject smallAsteroid2;
    private int bigAsteroidsNo;
    private int smallAsteroidsNo;

    [SerializeField] private int levelBigAsteroidsNo;
    [SerializeField] private int levelSmallAsteroidsNo;
    // Start is called before the first frame update
    [SerializeField] private static int score;
    [SerializeField] private static int lives;

    [SerializeField] private float topY;

    [SerializeField] private float bottomY;

    [SerializeField] private float rightX;

    [SerializeField] private float leftX;
    
    enum Stage {Space, Arrow, Score};
    Stage tutorialPart;

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
        tutorialPart = Stage.Space;
        tutorial.text = "Press space to shoot laser!"; 
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
    private void Update() 
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        
        if (tutorialPart == Stage.Space && (Input.GetButtonDown("Fire1")))
        {
            tutorial.text = "Use the arrow keys or WASD to maneuver around!";
            tutorialPart = Stage.Arrow;
        }
        else if (tutorialPart == Stage.Arrow && ((vertical!=0) || (horizontal!=0)))
        {
            tutorial.text = "Destory all asteroids! Make sure you keep an eye on your lives and score at the top!";
            tutorialPart = Stage.Score;
        }
        else if (tutorialPart == Stage.Score && ((bigAsteroidsNo == 0) && (smallAsteroidsNo == 0)))
        {
            GameOver();
        }
        Debug.Log(bigAsteroidsNo);
        Debug.Log(smallAsteroidsNo);
    }

    public void AddScore(int points,bool plus)
    {
        score += points;
        Debug.Log(score);
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
        if (lives == 0)
        {
            tutorialEndText.text ="Please try the tutorial again!";
        }
        else
        {
            tutorialEndText.text ="You're ready to try the actual game!";
        }
        gameOverPanel.SetActive(true);
    }


    public void GoMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void ReloadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}

