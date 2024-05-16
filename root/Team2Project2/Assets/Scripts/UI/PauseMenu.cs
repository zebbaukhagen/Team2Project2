using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private TMP_Text levelPrompt;
    [SerializeField] private UILevelController uiController;
    [SerializeField] private static bool togglePauseGame;
    [SerializeField] private static bool pauseGame;
    [SerializeField] private AudioManager audioManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        settingsMenu.SetActive(false);
        audioManager = AudioManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        togglePauseGame = !togglePauseGame;

        if (togglePauseGame == true)
        {
            //audioManager.PauseAudio();
            pauseMenu.SetActive(true);
            playerController.enabled = false;
            Time.timeScale = 0f;
          
            if (SceneManager.GetActiveScene().name == "LevelOne")
            {
                levelPrompt.text = "Level 1: Escape The Flames! ";
            }
            else if (SceneManager.GetActiveScene().name == "LevelTwo")
            {
                levelPrompt.text = "Level 2: Connect The Conduits! ";
            }
            if(SceneManager.GetActiveScene().name == "LevelThree")
            {
                levelPrompt.text = "Level 3: Escape The Roomba! ";
            }
        }
        else
        {
            //audioManager.PlayMusic();
            togglePauseGame = false;
            pauseMenu.SetActive(false);
            settingsMenu.SetActive(false);
            playerController.enabled = true;
            Time.timeScale = 1f;
        }
    }
    
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(!settingsMenu.activeSelf);
    }

    public void BackToMainMenu()
    {
        togglePauseGame = false;
        uiController.BackToMainMenu();
        pauseMenu.SetActive(false);
        playerController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
    }

}
