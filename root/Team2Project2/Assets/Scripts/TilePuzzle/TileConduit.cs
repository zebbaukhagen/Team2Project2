using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileConduit : MonoBehaviour
{
    [SerializeField] private TileSlot _parentSlot;
    [SerializeField] public SocketDirection[] _socketDirections { get; private set; }
    [SerializeField] private List<GameObject> listOfConduits = new();
    public bool PowerState { get; private set; } = false;

    [SerializeField] private Material onMaterial;
    [SerializeField] private Material offMaterial;


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

    public void SetPowerState(bool state)
    {
        PowerState = state;
        ChangeMaterial();
    }

    private void ChangeMaterial()
    {
        // set the material of the conduits to on or off colors
        foreach (GameObject conduit in listOfConduits)
        {
            Renderer rend = conduit.GetComponent<Renderer>();
            if (PowerState)
            {
                rend.material = onMaterial;
            }
            else
            {
                rend.material = offMaterial;
            }
        }
    }
}

public enum SocketDirection { TOP, BOTTOM, LEFT, RIGHT };
