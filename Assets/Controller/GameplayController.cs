using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class GameplayController : MonoBehaviour
{

    private TextMeshProUGUI scoreUI;
    // Start is called before the first frame update
    public int score {private set; get;}

    private void Awake()
    {
        score = 0;
        scoreUI - GetComponent<TextMeshProUGUI>();
    }

    public void AddScore(int points)
    {
        score += points;
        mtText.text = "Score: " + score.ToString();
    }
}
