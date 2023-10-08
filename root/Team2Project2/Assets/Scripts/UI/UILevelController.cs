using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevelController : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject pauseMenuPanel;
    private static UILevelController instance;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private AudioManager audioManager;

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
        audioManager = AudioManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        OpenPauseMenu();
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(!settingsMenu.activeSelf);
    }

    private void OpenPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.PauseGame();
        }
    }

    public void BackToMainMenu()
    {
        audioManager.PlayLevelMusic(0);
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game has been quit");
    }

    public void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            audioManager.PlayLevelMusic(nextSceneIndex);
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            audioManager.PlayLevelMusic(0);
            SceneManager.LoadScene(0);
        }
    }

}

