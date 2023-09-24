using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //[SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject pauseMenu;
   
     //[SerializeField] private static bool backToMainMenu = false;
     [SerializeField] private static bool togglePauseGame;

    // Start is called before the first frame update
    void Start()
    {

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
            playerController.enabled = false;
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            playerController.enabled = true;
            Time.timeScale = 1f;
        }
    }

    private void BackToMainMenu()
    {
        //sceneLoader.LoadScene(0);
        pauseMenu.SetActive(false);
        playerController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }
}
