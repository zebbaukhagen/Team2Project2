using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchButton : MonoBehaviour
{
    [SerializeField] List<SwitchTile> listOfConnectedTiles = new();


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
            Debug.Log("Switch activated by Player.");
            ToggleConnectedTileStates();
        }
    }
}
