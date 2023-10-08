using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private AudioManager audioManager;

    private void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioManager = AudioManager.instance;
    }

    private void Update()
    {
        CheatCodes();
    }

    public void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            LoadLevel(nextSceneIndex);
        }
        else
        {
            LoadLevel(0);
        }
    }

    public void LoadLevel(int buildIndexOfSceneToLoad)
    {
        audioManager.PlayLevelMusic(buildIndexOfSceneToLoad);
        SceneManager.LoadScene(buildIndexOfSceneToLoad);
    }

    private void CheatCodes()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            LoadLevel(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            LoadLevel(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LoadLevel(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            LoadLevel(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            LoadLevel(4);
        }
    }
}