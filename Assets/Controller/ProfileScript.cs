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
    [SerializeField] private int[] shotsHit;
    [SerializeField] private TextMeshProUGUI[]  highScoreTexts;
    [SerializeField] private Button editSaveButton;
    [SerializeField] private TextMeshProUGUI  editSaveButtonText;
    
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

                ProgramData.fillInfoFromFile();

                ReloadProfileGUI();
            }
            else
            {
                using (StreamWriter writer = File.CreateText(fullPath))
                {
                    writer.WriteLine("Player 1,Player 2,Player 3,0,0,0,0,0,0,0,0,0");
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
        for(int i = 0;i<3;i++)
        {
            profileNames[i].DeactivateInputField();
            profileNames[i].readOnly = true;
            profileNames[i].interactable = false;
            ProgramData.Names[i] = profileNames[i].text.ToString();
        }
        
        ProgramData.WriteFile();
        ProgramData.fillInfoFromFile();
        editSaveButtonText.text = "Edit";
    }

    public void GoMainMenu(int value)
    {
        ProgramData.Id = value;
        
        SceneManager.LoadScene("StartMenu");
    }
    public void ReloadProfileGUI()
    {
        profileNames[0].text = ProgramData.Names[0];
        profileNames[1].text = ProgramData.Names[1];
        profileNames[2].text = ProgramData.Names[2];

        highScoreTexts[0].text = "Highest level: " + ProgramData.HighestLevels[0]+ "\n" + "Asteroids destroyed: " + ProgramData.ShotsHit[0];
        highScoreTexts[1].text = "Highest level: " + ProgramData.HighestLevels[1]+ "\n" + "Asteroids destroyed: " + ProgramData.ShotsHit[1];
        highScoreTexts[2].text = "Highest level: " + ProgramData.HighestLevels[2]+ "\n" + "Asteroids destroyed: " + ProgramData.ShotsHit[2];
    }
}
