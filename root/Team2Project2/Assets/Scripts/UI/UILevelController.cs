using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevelController : MonoBehaviour
{
    private static UILevelController instance;

    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private PauseMenu pauseMenu;

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
        GameManager.instance.LoadLevel(1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game has been quit");
    }
}

