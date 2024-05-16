using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSlot : MonoBehaviour
{
    [SerializeField] private List<TileSlot> _listOfNeighborSlots = new();
    [SerializeField] private TileTile _currentChild;
    private bool _currentlyInhabited;
    public bool CurrentlyInhabited
    {
        get => _currentlyInhabited;
        private set => _currentlyInhabited = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (_currentChild != null) _currentlyInhabited = true;
    }

    public void AcceptNewChild(TileTile newChild)
    {
        // sets current child and toggles inhabited state
        if (!CurrentlyInhabited)
        {
            {
                _currentChild = newChild;
                ToggleInhabitedState();
            }
        }
    }

    public void ReleaseOldChild()
    {
        // lets go of the old child and toggles inhabited state
        _currentChild = null;
        ToggleInhabitedState();
    }

    private void ToggleInhabitedState()
    {
        CurrentlyInhabited = !CurrentlyInhabited;
    }

    public bool CheckForEmptyNeighbor(out TileSlot emptyNeighbor)
    {
        // Initialize emptyNeighbor to null as it's an out parameter
        emptyNeighbor = null;

        // looks through list of neighbors to see if any are empty
        foreach (TileSlot tileSlot in _listOfNeighborSlots)
        {
            if (!tileSlot.CurrentlyInhabited)
            {
                emptyNeighbor = tileSlot;
                return true;
            }
        }
        return false;
    }

    public List<TileConduit> ReturnListOfNeighboringConduits()
    {
        // look through list of neighboring slots, and return a list of the tileConduits in their children
        List<TileConduit> result = new();
        foreach (TileSlot neighbor in _listOfNeighborSlots)
        {
            if (neighbor.gameObject.TryGetComponent(out TileConduit tileConduit))
            {
                result.Add(tileConduit);
            }
        }
        return result;
    }
}
