using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTile : MonoBehaviour
{
    [SerializeField] private List<SwitchTile> neighboringTiles = new();
    [SerializeField] private bool activeState;

    public bool ActiveState { get; private set; }

    public void ToggleByProximity()
    {
        // toggles state locally only, to be called from another tile.
        ActiveState = !ActiveState;

    }

    public void ToggleBySwitch()
    {
        // toggles state from switch, also toggles neighbors
        ActiveState = !ActiveState;
        foreach (SwitchTile tile in neighboringTiles)
        {
            tile.ToggleByProximity();
        }
    }
}
