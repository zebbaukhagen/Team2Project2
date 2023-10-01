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
        if (other.CompareTag("Conduit") && other.GetComponentInParent<TileConduit>().PowerState == true)
        {
            Debug.Log("Power connected.");
            tileConduit.SetPowerState(true);
        }
        if (other.CompareTag("PowerSource"))
        {
            Debug.Log("Power connected.");
            tileConduit.SetPowerState(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Conduit") && other.gameObject.GetComponentInParent<TileConduit>().PowerState == false)
        {
            Debug.Log("Power disconnected.");
            tileConduit.SetPowerState(false);
        }
        if (other.CompareTag("PowerSource"))
        {
            Debug.Log("Power connected.");
            tileConduit.SetPowerState(false);
        }
    }
}
