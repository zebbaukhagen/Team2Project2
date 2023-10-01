using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSource : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Conduit"))
        {
            Debug.Log("Power source collision.");
            other.GetComponentInParent<TileConduit>().SetPowerState(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Conduit"))
        {
            Debug.Log("Power source collision.");
            other.GetComponentInParent<TileConduit>().SetPowerState(false);
        }
    }
}
