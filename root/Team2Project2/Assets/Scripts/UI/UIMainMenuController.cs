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
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private GameObject creditsMenu;
    [SerializeField] private InstructionsPanel instructions;

    private static UIMainMenuController instance;

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
        audioManager = AudioManager.instance;
    }

    public void GoToLevelOne()
    {
        GameManager.instance.LoadLevel(1);
    }

    public void OpenInstructions()
    {
        instructionsPanel.SetActive(!instructionsPanel.activeSelf);
        instructions.LevelOneSelected();
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(!settingsMenu.activeSelf);
    }

    public void OpenCredits()
    {
        creditsMenu.SetActive(!creditsMenu.activeSelf);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game has been quit.");
    }
}
