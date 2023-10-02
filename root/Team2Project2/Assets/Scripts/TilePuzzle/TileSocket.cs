using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSocket : MonoBehaviour
{
    private TileConduit tileConduit;

    private void Awake()
    {
        tileConduit = GetComponentInParent<TileConduit>();
        if (tileConduit == null) Debug.Log("No conduit connected.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Conduit"))
        {
            Debug.Log("Conduit connected.");
            tileConduit.ConnectConduit(other.GetComponentInParent<TileConduit>());
        }
        if (other.CompareTag("PowerReceiver"))
        {
            Debug.Log("PowerReceiver connected.");
            tileConduit.ConnectReceiver(other.GetComponent<PowerReceiver>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Conduit"))
        {
            Debug.Log("Power disconnected.");
            tileConduit.DisconnectConduit();
        }
        if (other.CompareTag("PowerReceiver"))
        {
            Debug.Log("PowerReceiver disconnected.");
            tileConduit.DisconnectReceiver();
        }
    }
}
