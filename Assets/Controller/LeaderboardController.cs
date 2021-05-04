using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using UnityEngine;
using TMPro;
using System.Text;

public class LeaderboardController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI  leaderboardText;
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
        string leaderText = "";
        
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
