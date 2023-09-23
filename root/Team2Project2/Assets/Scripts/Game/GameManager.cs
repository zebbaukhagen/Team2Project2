using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //[SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private PlayerController playerController;
    //public CamMouseLook camMouseLook;
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
            playerController.enabled = false;
            //camMouseLook.enabled = false;
            Time.timeScale = 0f;
        }
        else
        {
            playerController.enabled = true;
            //camMouseLook.enabled = true;
            Time.timeScale = 1f;
        }
    }

    private void BackToMainMenu()
    {
        //sceneLoader.LoadScene(0);
        playerController.enabled = false;
        //camMouseLook.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        //backToMainMenu = true;
    }
}