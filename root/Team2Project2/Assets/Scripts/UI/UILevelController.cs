using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevelController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;  // Make sure to assign this in the Unity Editor
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject pauseMenu;
    private static UILevelController instance;

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
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // You can add update logic here if needed
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

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OffloadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }

    public void NextLevel()
    {
        LoadScene("LevelTwo");
        OffloadScene("LevelOne");
    }
}
