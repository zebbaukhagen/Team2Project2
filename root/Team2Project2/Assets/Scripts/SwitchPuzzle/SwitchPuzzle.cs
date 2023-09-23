using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SwitchPuzzle : MonoBehaviour
{
    [SerializeField] private List<SwitchTile> listOfTiles = new();
    private bool puzzleSolved = false;

    public void CheckForSolution()
    {
        if (listOfTiles.Count(c => c.ActiveState) == listOfTiles.Count)
        {
            Debug.Log("Puzzle Solved!");
            puzzleSolved = true;
        }
    }

    public void AddChildTileToList(SwitchTile tile)
    {
        listOfTiles.Add(tile);
    }
}
