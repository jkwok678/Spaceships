using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MenuScript : MonoBehaviour

{
    [SerializeField] private TextMeshProUGUI welcomeMessage;
    // Start is called before the first frame update
    void Start()
    {
        welcomeMessage.text = "Welcome " + ProgramData.Names[ProgramData.Id];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoProfileScene();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Transition");
    }

    public void StartTutorial()
    {
        SceneManager.LoadScene("TransitionTutorial");
    }

    public void GoLeaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void GoProfileScene()
    {
        SceneManager.LoadScene("ProfileMenu");
    }
}
