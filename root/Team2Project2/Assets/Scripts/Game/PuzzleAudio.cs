using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleAudio : MonoBehaviour
{
    [SerializeField] private List<AudioClip> listOfPuzzleClips = new();
    [SerializeField] private AudioClip puzzleSolvedClip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRandomPuzzleClip()
    {
        int randomChoice = Random.Range(0, listOfPuzzleClips.Count - 1);
        audioSource.PlayOneShot(listOfPuzzleClips[randomChoice]);
    }

    public void PlaySolvedClip()
    {
        audioSource.PlayOneShot(puzzleSolvedClip);
    }
}
