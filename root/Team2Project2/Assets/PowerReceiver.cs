using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerReceiver : MonoBehaviour
{
    [SerializeField] private bool puzzleSolved = false;
    [SerializeField] private Door finishDoor;
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

        messageProcessed = false; // Reset for future messages
    }

    private void SolvePuzzle()
    {
        // Do anything necessary when puzzle is solved like open doors
        Debug.Log(transform.root.name + " solved!");
        puzzleSolved = true;
        OpenFinishDoor();
    }

    private void OpenFinishDoor()
    {
        if (finishDoor == null) { Debug.Log("No door attached."); }
        else
        {
            // open the final door
            finishDoor.SetDoorStatus(DoorStatus.OPEN);
        }
    }
}
