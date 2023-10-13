using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private List<Sprite> greyscaleImages = new();
    [SerializeField] private List<Sprite> coloredImages = new();

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.instance;
        //gameManager.ListOfLevelsCompleted
    }

    void Update()
    {
        
    }
}
