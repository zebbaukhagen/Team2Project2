using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;   
    [SerializeField] private GameObject instructionsPanel;
    [SerializeField] private GameObject settingsMenu;
    private static UIController instance;
    [SerializeField] private static UIController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIController>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("UIController");
                    instance = singletonObject.AddComponent<UIController>();
                }
            }
            return instance;
        }
    }

    void start()
    {
        instructionsPanel.SetActive(false);
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        
    }

    public void OffloadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }
    

    public void StartGame()
    {
        LoadScene("LevelOne");
        OffloadScene("MainMenu");
    }

    public void OpenInstructions()
    {
        instructionsPanel.SetActive(!instructionsPanel.activeSelf); 
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(!settingsMenu.activeSelf);
    }


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Has Been Quit");
    }
}
