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

    private void OnEnable()
    {
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        int currentIndex = 0;
        foreach (bool level in gameManager.ListOfLevelsCompleted)
        {
            Debug.Log("I am in the for loop" + level);
            
            Debug.Log(currentIndex + " " + level);  
            if (level)
            {
                levelImages[currentIndex].sprite = coloredImages[currentIndex];
                levelButtons[currentIndex].interactable = true;
            }
            currentIndex++;
        }
    }

    public void OnClickLevelSelect(int buttonNumber)
    {
        gameManager.LoadLevel(buttonNumber + 3);
    }
}
