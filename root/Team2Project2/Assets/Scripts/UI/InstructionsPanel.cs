using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class InstructionsPanel : MonoBehaviour
{
    [SerializeField] private GameObject LevelOneButton;
    [SerializeField] private GameObject LevelTwoButton;
    [SerializeField] private GameObject LevelThreeButton;
    [SerializeField] private TMP_Text levelTitleText;
    [SerializeField] private TMP_Text levelDetails;
    [SerializeField] private UIMainMenuController levelJump;
    [SerializeField] private AudioManager audioManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelOneSelected()
    {
        levelTitleText.text = " Level One: Escape the Flames";
        levelDetails.text = "Complete the following binary puzzles to turn off the fires blocking the doors and scamper your way to the exit progressing to Level Two";
    }

    public void LevelTwoSelected()
    {
        levelTitleText.text = " Level Two: Connect the Electric Conduits";
        levelDetails.text = "Complete the electrical current puzzles in each area of the room by moving the tiles around the designated play section of each zone, and make your way to Level Three";
    }

    public void LevelThreeSelected() 
    {
        levelTitleText.text = " Level Three: Avoid the Roombas!";
        levelDetails.text = "Maneuver through the maze, and move the fuses to their designated color location. The fuse are needed to unlock the Scientist's Lab. Avoid the Roombas traveling around the room, then exact your revenge on your abuser.";
    }

    public void GameControls()
    {
        levelTitleText.text = "Game Controls";
        levelDetails.text = "Press A to move LEFT, \n" +
            "Press W to move UP, \n" +
            "Press S to move DOWN, \n" +
            "Press D to move RIGHT.\n" +
            "You can also use the arrow keys to move as well. \n";       
    }
}

