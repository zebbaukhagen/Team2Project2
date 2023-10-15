using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private List<Sprite> coloredImages = new();
    [SerializeField] private List<Image> levelImages = new();
    [SerializeField] private List<Button> levelButtons = new();

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.instance;
    }

    private void InitializeButtons()
    {
        foreach (bool level in gameManager.ListOfLevelsCompleted)
        {
            Debug.Log("I am getting to this point");
            int currentIndex = gameManager.ListOfLevelsCompleted.IndexOf(level);
            if (level)
            {
                levelImages[currentIndex].sprite = coloredImages[currentIndex];
                levelButtons[currentIndex].interactable = true;
            }
        }
    }

    public void OnClickLevelSelect(int buttonNumber)
    {
        gameManager.LoadLevel(buttonNumber + 2);
    }
}
