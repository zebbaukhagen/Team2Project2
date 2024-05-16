using System;
using System.Collections;
using UnityEngine;

public class PowerSource : MonoBehaviour
{
    [SerializeField] TileConduit connectedConduit;
    [SerializeField] PowerReceiver pairedReceiver;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Conduit"))
        {
            Debug.Log("Power source collision.");
            connectedConduit = other.GetComponentInParent<TileConduit>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Conduit"))
        {
            Debug.Log("Power source disconnected.");
            SendMessage(false);
            connectedConduit = null;
        }
    }

    private void Start()
    {
        StartCoroutine(TransmitMessage());
    }

    private IEnumerator TransmitMessage()
    {
        while (pairedReceiver.PuzzleSolved == false)
        {
            if (connectedConduit != null)
            {
                SendMessage(true);
            }
            yield return new WaitForSeconds(.1f);
        }
        yield return null;

    }

    private void SendMessage(bool powered)
    {
        connectedConduit.ReceiveMessage(powered);
    }
}
