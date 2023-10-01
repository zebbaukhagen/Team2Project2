using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileConduit : MonoBehaviour
{
    [SerializeField] private TileSlot _parentSlot;
    [SerializeField] private SocketDirection[] _socketDirections;
    [SerializeField] private bool _powerState = false;

    private void Start()
    {
        if (_parentSlot == null)
        {
            TryToAssignParent();
        }
    }

    private void TryToAssignParent()
    {
        // attempt to assign parent TileSlot, log error on failure
        TileSlot possibleParent;
        possibleParent = GetComponentInParent<TileSlot>();
        if (possibleParent != null)
        {
            _parentSlot = possibleParent;
        }
        else
        {
            Debug.Log("Tile: " + gameObject.name + "failed to assign parent slot.");
        }
    }
}

public enum SocketDirection { TOP, BOTTOM, LEFT, RIGHT };
