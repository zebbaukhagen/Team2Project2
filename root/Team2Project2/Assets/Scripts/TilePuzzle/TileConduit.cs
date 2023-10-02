using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class TileConduit : MonoBehaviour
{
    [SerializeField] private TileSlot _parentSlot;
    [SerializeField] private List<GameObject> listOfConduits = new();

    [SerializeField] private Material onMaterial;
    [SerializeField] private Material offMaterial;

    [SerializeField] private TileConduit connectedConduit;

    private bool messageProcessed = false;


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

    public void ConnectConduit(TileConduit newConduit)
    {
        connectedConduit = newConduit;
    }

    public void DisconnectConduit()
    {
        SendMessage(false);
        connectedConduit = null;
    }

    public void ReceiveMessage(bool powered)
    {
        if (messageProcessed) // Exit condition
        {
            return;
        }

        messageProcessed = true; // Mark this instance as processed

        if (powered == true)
        {
            ChangeMaterial(true);
            SendMessage(powered);
        }
        else if (powered == false)
        {
            ChangeMaterial(false);
            SendMessage(powered);
        }

        messageProcessed = false; // Reset for future messages
    }

    private void SendMessage(bool powered)
    {
        if (connectedConduit != null)
        {
            connectedConduit.ReceiveMessage(powered);
        }
        else
        {
            return;
        }
    }

    private void ChangeMaterial(bool powerState)
    {
        // set the material of the conduits to on or off colors
        foreach (GameObject conduit in listOfConduits)
        {
            Renderer rend = conduit.GetComponent<Renderer>();
            if (powerState)
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
