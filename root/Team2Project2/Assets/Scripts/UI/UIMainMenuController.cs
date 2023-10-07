using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject instructionsPanel;
    [SerializeField] private GameObject settingsMenu;
    private static UIMainMenuController instance;
    [SerializeField] private AudioManager aManager;
 

    public static UIMainMenuController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIMainMenuController>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("UIMainMenuController");
                    instance = singletonObject.AddComponent<UIMainMenuController>();
                }
            }
            return instance;
        }
    }

    private void Start()
    {
        QualitySettings.SetQualityLevel(3);
        instructionsPanel.SetActive(false);
        settingsMenu.SetActive(false);
     
    }

    public void GoToLevelOne()
    {
        SceneManager.LoadScene(2);
        aManager.PlayNextAudioClip();
    }

    public void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;


        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
            aManager.PlayNextAudioClip ();
        }
        else
        {
            SceneManager.LoadScene(0);
        }

    }

    public void OpenInstructions()
    {
        instructionsPanel.SetActive(!instructionsPanel.activeSelf);
    }

    public void OpenSettings()
    {
        aManager.ClickSound();
        settingsMenu.SetActive(!settingsMenu.activeSelf);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game has been quit");
    }
}
