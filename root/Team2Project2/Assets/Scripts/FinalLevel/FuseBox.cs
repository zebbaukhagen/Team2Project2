using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBox : MonoBehaviour
{
    [SerializeField] private Transform fuseLocation;
    [SerializeField] private Fuse matchingFuse;

    private bool fuseConnected = false;

    public bool FuseConnected
    {
        get => fuseConnected;
        private set => fuseConnected = value;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fuse"))
        {
            CheckFuse(other.GetComponent<Fuse>());
        }
    }

    private void CheckFuse(Fuse fuse)
    {
        //if ()

    }

    private void AcceptFuse()
    {
        // Takes the matching fuse from the player, sets the parent and the transform

    }

    private void TurnLightsOn()
    {
        // Activates the connected lights and checks the level for completion

    }
}
