using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerReceiver : MonoBehaviour
{
    [SerializeField] private bool puzzleSolved = false;
    private bool messageProcessed = false;

    public bool PuzzleSolved
    {
        get => puzzleSolved;
        private set => puzzleSolved = value;
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
            SolvePuzzle();
        }
        else if (powered == false)
        {
            return;
        }

        messageProcessed = false; // Reset for future messages
    }

    private void SolvePuzzle()
    {
        // Do anything necessary when puzzle is solved like open doors
        Debug.Log(transform.root.name + " solved!");
        puzzleSolved = true;
    }
}
