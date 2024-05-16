using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SwitchPuzzle : MonoBehaviour
{
    [SerializeField] private List<SwitchTile> listOfTiles = new();
    [SerializeField] private List<FireController> listOfFireControllers = new();
    [SerializeField] private List<Light> listOfLights = new();
    [SerializeField] private Door finishDoor;
    private PuzzleAudio puzzleAudio;
    private bool puzzleSolved = false;

    private void Awake()
    {
        puzzleAudio = GameObject.Find("Level1Audio").GetComponent<PuzzleAudio>();
    }

    public void CheckForSolution()
    {
        if (!puzzleSolved)
        {
            // Check if all tiles in the list of tiles are true
            if (listOfTiles.Count(c => c.ActiveState) == listOfTiles.Count)
            {
                // if so, puzzle is solved
                Debug.Log("Puzzle Solved!");
                puzzleAudio.PlaySolvedClip();
                puzzleSolved = true;
                OpenFinishDoor();
                TurnFiresOff();
                TurnLightsOn();
            }
        }
    }

    private void OpenFinishDoor()
    {
        if (finishDoor == null) { Debug.Log("No door attached."); }
        else
        {
            // open the final door
            finishDoor.SetDoorStatus(DoorStatus.OPEN);
        }
    }

    private void TurnFiresOff()
    {
        if (listOfFireControllers.Count == 0) { Debug.Log("No fires attached."); }
        else
        {
            foreach (FireController fire in listOfFireControllers)
            {
                fire.ToggleParticleSystem();
            }
        }
    }

    private void TurnLightsOn()
    {
        if (listOfLights.Count == 0) { Debug.Log("No lights attached."); }
        foreach (Light light in listOfLights)
        {
            light.enabled = true;
        }
    }

    public void AddChildTileToList(SwitchTile tile)
    {
        // method to be called from tiles
        listOfTiles.Add(tile);
    }

    public void AddChildFireToList(FireController fire)
    {
        // to be called from FireControllers
        listOfFireControllers.Add(fire);
    }
}
