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
    private GameManager gameManager;

    private void Start()
    {
        QualitySettings.SetQualityLevel(3);
        instructionsPanel.SetActive(false);
        settingsMenu.SetActive(false);
        audioManager = AudioManager.instance;
        gameManager = GameManager.instance;
    }

    public void GoToLevelOne()
    {
        gameManager.LoadLevel(1);
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
