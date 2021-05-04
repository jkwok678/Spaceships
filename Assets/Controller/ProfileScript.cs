using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;
public class ProfileScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Button[] profileButtons;
    [SerializeField] private TMP_InputField[] profileNames;
    [SerializeField] private int[] highScores;
    [SerializeField] private int[] shots;
     [SerializeField] private TextMeshProUGUI[]  highScoreTexts;
    [SerializeField] private Button editSaveButton;
    [SerializeField] private TextMeshProUGUI  editSaveButtonText;
    [SerializeField] private ProgramData  myProgramData; 
    string fullPath;
    private bool editMode;
    void Start()
    {
        StreamWriter file;
        editMode = false;
        editSaveButtonText.text = "Edit";
        fullPath = Application.persistentDataPath + "/profile.txt";
        Debug.Log(Application.persistentDataPath);
        try
        {
            if (File.Exists(fullPath))
            {
                string fileContent = File.ReadAllText(fullPath);
                string[] infoFromFile = fileContent.Split(',');
                Debug.Log(infoFromFile[0]);
                Debug.Log(infoFromFile[1]);
                Debug.Log(infoFromFile[2]);

                profileNames[0].text = infoFromFile[0];
                profileNames[1].text = infoFromFile[1];
                profileNames[2].text = infoFromFile[2];
                highScores[0] = Int32.Parse(infoFromFile[3]);
                highScores[1] = Int32.Parse(infoFromFile[4]);
                highScores[2] = Int32.Parse(infoFromFile[5]);
                highScoreTexts[0].text = "Highest level: " + highScores[0];
                highScoreTexts[1].text = "Highest level: " + highScores[1];
                highScoreTexts[2].text = "Highest level: " + highScores[2];
                shots[0] = Int32.Parse(infoFromFile[6]);
                shots[1] = Int32.Parse(infoFromFile[7]);
                shots[2] = Int32.Parse(infoFromFile[8]);
            }
            else
            {
                using (StreamWriter writer = File.CreateText(fullPath))
                {
                    writer.WriteLine("Player 1,Player 2,Player 3,0,0,0,0,0,0");
                }
            }
            
 
        }
        catch (Exception e)
        {
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HandleEditSaveButton()
    {
        if (editMode)
        {
            saveNames();
        
        }
        else
        {
            editNames();
        }
    }

    public void editNames()
    {
        editMode = true;
        for (int i = 0; i<3;i++)
        {
            profileNames[i].ActivateInputField();
            profileNames[i].readOnly = false;
            profileNames[i].interactable = true;

        }

        editSaveButtonText.text = "Save";
    }

    public void saveNames()
    {
        editMode = false;
        string toWrite="";
        for (int i=0;i<3;i++)
        {
            profileNames[i].DeactivateInputField();
            profileNames[i].readOnly = true;
            profileNames[i].interactable = false;
            toWrite+=profileNames[i].text.ToString();
            toWrite+=",";
        }
        
        
        File.WriteAllText(fullPath, toWrite);
        editSaveButtonText.text = "Edit";
    }

    public void GoMainMenu(int value)
    {
        myProgramData.id = value;
        myProgramData.currentName = profileNames[value].text.ToString();
        myProgramData.currentHighScore = highScores[value];
        SceneManager.LoadScene("StartMenu");
    }
}
