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
    [SerializeField] private Button button1;
    [SerializeField] private Button button2;
    [SerializeField] private Button button3;
    [SerializeField] private Button button4;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip hoverSound;
    [SerializeField] private AudioClip clickSound;

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
        instructionsPanel.SetActive(false);
        settingsMenu.SetActive(false);
        button1 = GetComponent<Button>();
        button2 = GetComponent<Button>();
        button3 = GetComponent<Button>();
        button4 = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = hoverSound;
        audioSource.clip = clickSound;
        button1.onClick.AddListener(PlayClickSound);
        button2.onClick.AddListener(PlayClickSound);
        button3.onClick.AddListener(PlayClickSound);
        button4.onClick.AddListener(PlayClickSound);
    }

    public void GoToLevelOne()
    {
        SceneManager.LoadScene(2);
    }

    public void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;


        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
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
        settingsMenu.SetActive(!settingsMenu.activeSelf);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game has been quit");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (audioSource && hoverSound)
            Debug.Log("ping");
            audioSource.Play();
    }

     public void OnPointerExit(PointerEventData eventData)
    {
        if (audioSource && hoverSound)
            Debug.Log("Pong");
            audioSource.Stop();
    }
    
    void PlayClickSound()
    {
        if (audioSource && clickSound)
            audioSource.PlayOneShot(clickSound);
    }
}
