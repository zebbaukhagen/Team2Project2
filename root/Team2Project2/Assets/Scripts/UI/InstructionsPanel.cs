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
    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        LevelOneSelected();
        renderer = GetComponent<Renderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelOneSelected()
    {
        renderer.material.color = Color.black;
        levelTitleText.text = " Level One: Escape the Flames";
        levelDetails.text = "Complete the following binary puzzles to turn off the fires that are blocking the doors and make it to the exit to progress to Level Two";
    }

    public void LevelTwoSelected()
    {
        renderer.material.color = Color.black;
        levelTitleText.text = " Level Two: Connect the Conduits";
        levelDetails.text = "Complete the electrical current to unlock the main door, and progress to Level Three";
    }

    public void LevelThreeSelected() 
    {
        renderer.material.color = Color.black;
        levelTitleText.text = " Level Three: Roombas are hungry!";
        levelDetails.text = "Maneuver through the maze, collecting fuse pickups that are needed to unlock the Scientist Lab, then extract revenge on your abuser ";
    }
}

