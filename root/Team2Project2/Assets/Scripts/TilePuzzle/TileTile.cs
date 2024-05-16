using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTile : MonoBehaviour
{
    [SerializeField] private TileSlot _parentSlot;
    [SerializeField] private GameObject _rat;
    [SerializeField] private GameObject prefabParent;
    private PuzzleAudio puzzleAudio;

    // Start is called before the first frame update
    void Start()
    {
        if (_parentSlot == null)
        {
            TryToAssignParent();
        }
        if (_rat == null)
        {
            _rat = GameObject.Find("Rat");
        }
        puzzleAudio = GameObject.Find("Puzzle2Audio").GetComponent<PuzzleAudio>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TryToAssignParent()
    {
        // attempt to assign parent TileSlot, log error on failure
        TileSlot possibleParent;
        possibleParent = GetComponentInParent<TileSlot>();
        if (possibleParent != null)
        {
            _parentSlot = possibleParent;
            _parentSlot.AcceptNewChild(this);
        }
        else
        {
            Debug.Log("Tile: " + gameObject.name + "failed to assign parent slot.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // check for any empty neighbors, and return one if it exists
            if (_parentSlot.CheckForEmptyNeighbor(out TileSlot possibleEmptyParent))
            {
                Debug.Log("Player entered tile " + gameObject.name);
                // unparent the object from the slot, get the transform of the new one,
                // assign a new parent and update slot dependencies, start coroutine to move to new position
                _parentSlot.ReleaseOldChild();
                Vector3 newPosition = possibleEmptyParent.transform.position;
                _parentSlot = possibleEmptyParent;
                _parentSlot.AcceptNewChild(this);
                puzzleAudio.PlayRandomPuzzleClip();
                StartCoroutine(LerpPosition(newPosition, 1));
            }
            else
            {
                return;
            }
        }
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = prefabParent.transform.position;
        while (time < duration)
        {
            prefabParent.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        prefabParent.transform.position = targetPosition;
    }
}