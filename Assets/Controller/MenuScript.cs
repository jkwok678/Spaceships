using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MenuScript : MonoBehaviour

{
    [SerializeField] private ProgramData  myProgramData; 
    [SerializeField] private TextMeshProUGUI welcomeMessage;
    // Start is called before the first frame update
    void Start()
    {
        welcomeMessage.text = "Welcome " + myProgramData.currentName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
