using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTile : MonoBehaviour
{
    [SerializeField] private TileSlot _parentSlot;

    // Start is called before the first frame update
    void Start()
    {
        if (_parentSlot == null)
        {
            TryToAssignParent();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
