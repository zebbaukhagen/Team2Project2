using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private List<Sprite> coloredImages = new();
    [SerializeField] private List<RawImage> levelImages = new();
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
            int currentIndex = gameManager.ListOfLevelsCompleted[level];
            if (level)
            {

            }
        }
    }
}
