using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Text;

public class LeaderboardController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI  leaderboardText;
    [SerializeField] private TextMeshProUGUI  leaderboardText2;
    // Start is called before the first frame update
    void Start()
    {
        string fullPath = Application.persistentDataPath + "/profile.txt";
        string fileContent = File.ReadAllText(fullPath);
        string[] infoFromFile = fileContent.Split(',');


        List<string> names = new List<string>();
        names.Add(infoFromFile[0]);
        names.Add(infoFromFile[1]);
        names.Add(infoFromFile[2]);

        List<int> highScores = new List<int>();
        highScores.Add(Int32.Parse(infoFromFile[3]));
        highScores.Add(Int32.Parse(infoFromFile[4]));
        highScores.Add(Int32.Parse(infoFromFile[5]));
        string leaderText = "Highest level \n";
        int[] shots = new int[3];
        int[] shotsHit = new int[3];
        shots[0] = Int32.Parse(infoFromFile[6]);
        shots[1] = Int32.Parse(infoFromFile[7]);
        shots[2] = Int32.Parse(infoFromFile[8]);
        shotsHit[0] = Int32.Parse(infoFromFile[9]);
        shotsHit[1] = Int32.Parse(infoFromFile[10]);
        shotsHit[2] = Int32.Parse(infoFromFile[11]);
        ProgramData.Shots = shots;
        ProgramData.ShotsHit = shotsHit;
        
        for(int i = 0;i<3;i++)
        {
            int maxValue = highScores.Max();
            int maxIndex = highScores.IndexOf(maxValue);
            int j = i+1;
            leaderText += (j).ToString() +". " + names[maxIndex] + "   " + highScores[maxIndex] + "\n";
            names.RemoveAt(maxIndex);
            highScores.RemoveAt(maxIndex);
        }
        leaderboardText.text = leaderText;
        names.Add(infoFromFile[0]);
        names.Add(infoFromFile[1]);
        names.Add(infoFromFile[2]);

        List<float> percentage = new List<float>();
        for(int i = 0; i<3;i++)
        {
            percentage.Add((float)ProgramData.ShotsHit[i]/(float)ProgramData.Shots[i]);
        }
        string leaderText2 = "Highest shot accuracy  \n";
        for(int i = 0;i<3;i++)
        {
            float maxValue = percentage.Max();
            int maxIndex = percentage.IndexOf(maxValue);
            int j = i+1;
            leaderText2 += (j).ToString() +". " + names[maxIndex] + "   " + (percentage[maxIndex]*100).ToString() + "%\n";
            names.RemoveAt(maxIndex);
            percentage.RemoveAt(maxIndex);
        }
        leaderboardText2.text = leaderText2;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoMainMenu();
        }
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
