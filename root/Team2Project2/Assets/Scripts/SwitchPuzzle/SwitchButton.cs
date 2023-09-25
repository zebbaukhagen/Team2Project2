using System.Collections.Generic;
using UnityEngine;

public class SwitchButton : MonoBehaviour
{
    [SerializeField] private List<SwitchTile> listOfConnectedTiles = new();
    [SerializeField] private List<Door> listOfConnectedDoors = new();

    private bool hasConnectedDoors = false;

    private SwitchPuzzle parentPuzzle;

    private void Awake()
    {
        parentPuzzle = GetComponentInParent<SwitchPuzzle>();
        if (listOfConnectedDoors.Count > 0) hasConnectedDoors = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // activates toggling on player collision
        if (other.CompareTag("Player"))
        {
            ToggleConnectedTileStates();
            parentPuzzle.CheckForSolution();
            if (hasConnectedDoors)
            {
                ToggleConnecteDoorStates();
            }
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

    private void ToggleConnecteDoorStates()
    {
        // toggles states of all connected doors
        foreach (Door door in listOfConnectedDoors)
        {
            door.ToggleDoor();
        }
    }
}
