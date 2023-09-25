using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SwitchPuzzle : MonoBehaviour
{
    [SerializeField] private List<SwitchTile> listOfTiles = new();
    [SerializeField] private Door finishDoor; 

    public void CheckForSolution()
    {
        // Check if all tiles in the list of tiles are true
        if (listOfTiles.Count(c => c.ActiveState) == listOfTiles.Count)
        {
            // if so, puzzle is solved
            Debug.Log("Puzzle Solved!");
            if (finishDoor == null) { Debug.Log("No door attached."); }
            else
            {
                // open the final door
                finishDoor.SetDoorStatus(DoorStatus.OPEN);
            }

        }
    }

    public void AddChildTileToList(SwitchTile tile)
    {
        // method to be called from tiles
        listOfTiles.Add(tile);
    }
}
