using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchButton : MonoBehaviour
{
    [SerializeField] List<SwitchTile> listOfConnectedTiles = new();
    private SwitchPuzzle parentPuzzle;

    private void Awake()
    {
        parentPuzzle = GetComponentInParent<SwitchPuzzle>();
    }

    private void ToggleConnectedTileStates()
    {
        // toggles the states of all tiles connected to this switch
        foreach (SwitchTile tile in listOfConnectedTiles)
        {
            tile.ToggleBySwitch();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        // activates toggling on player collision
        if (other.CompareTag("Player"))
        {
            ToggleConnectedTileStates();
            parentPuzzle.CheckForSolution();
        }
    }
}
