using System.Collections.Generic;
using UnityEngine;

public class SwitchButton : MonoBehaviour
{
    [SerializeField] private List<SwitchTile> listOfConnectedTiles = new();
    [SerializeField] private List<Door> listOfConnectedDoors = new();
    [SerializeField] private List<FireController> listOfConnectedFires = new();

    private PuzzleAudio puzzleAudio;

    private bool hasConnectedTiles = false;
    private bool hasConnectedDoors = false;
    private bool hasConnectedFires = false;

    private SwitchPuzzle parentPuzzle;

    private void Awake()
    {
        parentPuzzle = GetComponentInParent<SwitchPuzzle>();
        puzzleAudio = GameObject.Find("Level1Audio").GetComponent<PuzzleAudio>();
        if (listOfConnectedTiles.Count > 0) hasConnectedTiles = true;
        if (listOfConnectedDoors.Count > 0) hasConnectedDoors = true;
        if (listOfConnectedFires.Count > 0) hasConnectedFires = true;
        //Debug.Log("Awake in GameObject " + gameObject.name + " - listOfConnectedFires Count: " + listOfConnectedFires.Count);
    }

    private void OnTriggerEnter(Collider other)
    {
        // activates toggling on player collision
        if (other.CompareTag("Player"))
        {
            puzzleAudio.PlayRandomPuzzleClip();
            Debug.Log("Player collided with button.");
            if (hasConnectedTiles)
            {
                Debug.Log("Toggling connected doors.");
                ToggleConnectedTileStates();
            }
            if (hasConnectedDoors)
            {
                Debug.Log("Toggling connected doors.");
                ToggleConnectedDoorStates();
            }
            if (hasConnectedFires)
            {
                Debug.Log("Toggling connected fires.");
                ToggleConnectedFireStates();
            }
            parentPuzzle.CheckForSolution();
        }
    }
    private void ToggleConnectedTileStates()
    {
        // toggles the states of all tiles connected to this switch
        foreach (SwitchTile tile in listOfConnectedTiles)
        {
            tile.ToggleBySwitch();
        }
    }

    private void ToggleConnectedDoorStates()
    {
        // toggles states of all connected doors
        foreach (Door door in listOfConnectedDoors)
        {
            door.ToggleDoor();
        }
    }

    private void ToggleConnectedFireStates()
    {
        // toggles state of connected fires
        foreach (FireController fire in listOfConnectedFires)
        {
            fire.ToggleParticleSystem();
        }
    }
}
