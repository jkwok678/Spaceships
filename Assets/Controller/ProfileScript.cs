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
    [SerializeField] private Button profile1Button;
    [SerializeField] private Button profile2Button;
    [SerializeField] private Button profile3Button;
    [SerializeField] private Button[] profileButtons;
    [SerializeField] private TMP_InputField profile1Name;
    [SerializeField] private TMP_InputField profile2Name;
    [SerializeField] private TMP_InputField profile3Name;
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
                string[] profileNames = fileContent.Split('\n');
                Debug.Log(profileNames[0]);
                Debug.Log(profileNames[1]);
                Debug.Log(profileNames[2]);

                profile1Name.text = profileNames[0];
                profile2Name.text = profileNames[1];
                profile3Name.text = profileNames[2];
            }
            else
            {
                using (StreamWriter writer = File.CreateText(fullPath))
                {
                    writer.WriteLine("Player 1");
                    writer.WriteLine("Player 2");
                    writer.WriteLine("Player 3");
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
        profile1Name.ActivateInputField();
        profile2Name.ActivateInputField();
        profile3Name.ActivateInputField();
        profile1Name.readOnly = false;
        profile2Name.readOnly = false;
        profile3Name.readOnly = false;
        profile1Name.interactable = true;
        profile2Name.interactable = true;
        profile3Name.interactable = true;

        editSaveButtonText.text = "Save";
    }

    public void saveNames()
    {
        editMode = false;
        profile1Name.DeactivateInputField();
        profile2Name.DeactivateInputField();
        profile3Name.DeactivateInputField();
        profile1Name.readOnly = true;
        profile2Name.readOnly = true;
        profile3Name.readOnly = true;
        profile1Name.interactable = false;
        profile2Name.interactable = false;
        profile3Name.interactable = false;
        using (StreamWriter writer = File.CreateText(fullPath))
        {
            writer.WriteLine(profile1Name.text.ToString());
            writer.WriteLine(profile2Name.text.ToString());
            writer.WriteLine(profile3Name.text.ToString());
        }
        editSaveButtonText.text = "Edit";
    }

    public void GoMainMenu(int value)
    {
        //myProgramData.Profile = profile;
        SceneManager.LoadScene("StartMenu");
        
    }
    
}
