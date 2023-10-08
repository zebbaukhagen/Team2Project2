using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevelController : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject pauseMenuPanel;
    private static UILevelController instance;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private AudioManager aManager;

    public static UILevelController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UILevelController>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("UILevelController");
                    instance = singletonObject.AddComponent<UILevelController>();
                }
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        settingsMenu.SetActive(false);
        pauseMenuPanel.SetActive(false);
        QualitySettings.SetQualityLevel(3);
    }

    // Update is called once per frame
    void Update()
    {
        OpenPauseMenu();
    }

    public void OpenSettings()
    {
        aManager.ClickSound();
        settingsMenu.SetActive(!settingsMenu.activeSelf);
    }

    private void OpenPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            aManager.ClickSound();
            pauseMenu.PauseGame();
        }
    }

    public void BackToMainMenu()
    {
        aManager.ClickSound();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        aManager.ClickSound();
        Application.Quit();
        Debug.Log("Game has been quit");
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

}

