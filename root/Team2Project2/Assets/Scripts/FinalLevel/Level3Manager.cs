using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    [SerializeField] private Door connectedDoor;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject finishLight;

    private int puzzlesSolved = 0;
    private readonly int totalPuzzles = 3;  // Replace with your total number of puzzles

    private void OnEnable()
    {
        FuseBox.OnPuzzleSolved += IncrementPuzzlesSolved;  // Subscribe to the event
    }

    private void OnDisable()
    {
        FuseBox.OnPuzzleSolved -= IncrementPuzzlesSolved;  // Unsubscribe to prevent memory leaks
    }

    private void IncrementPuzzlesSolved()
    {
        Debug.Log("Puzzle solved! " + (totalPuzzles - puzzlesSolved) + "/" + totalPuzzles + " left!");
        puzzlesSolved++;
        CheckForWin();
    }

    private void CheckForWin()
    {
        if (puzzlesSolved >= totalPuzzles)
        {
            Debug.Log("You've solved all puzzles! You win!");
            audioSource.Play();
            connectedDoor.ToggleDoor();
            finishLight.SetActive(true);
        }
    }
}
