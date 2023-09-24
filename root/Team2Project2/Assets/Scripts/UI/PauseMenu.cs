using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //[SerializeField] private SceneLoader sceneLoader;
    //[SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private TMP_Text levelPrompt;

    //[SerializeField] private static bool backToMainMenu = false;
    [SerializeField] private static bool togglePauseGame;

    // Start is called before the first frame update
    void Start()
    {
        settingsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMainMenu();
        }
    }

    public void PauseGame()
    {
        togglePauseGame = !togglePauseGame;

        if (togglePauseGame == true)
        {
            pauseMenu.SetActive(true);
            //playerController.enabled = false;
            Time.timeScale = 0f;
            if(SceneManager.GetActiveScene().name == "MainMenu")
            {
                levelPrompt.text = "THIS IS A TEST!";
            }
            //else if(SceneManager.GetActiveScene().name == "LevelOne")
            //{
            //    levelPrompt.text = "Level 1: Escape The Flames! ";
            //}
            //if(SceneManager.GetActiveScene().name == "LevelTwo")
            //{
            //    levelPrompt.text = "Level 2: Connect The Conduits! ";
            //}
            //else if (SceneManager.GetActiveScene().name == "LevelThree")
            //{
            //    levelPrompt.text = "Level 1: Escape The Roomba! ";
            //}
        }
        else
        {
            pauseMenu.SetActive(false);
            //playerController.enabled = true;
            Time.timeScale = 1f;
        }
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(!settingsMenu.activeSelf);
    }

    private void BackToMainMenu()
    {
        //sceneLoader.LoadScene(0);
        pauseMenu.SetActive(false);
       // playerController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

}
