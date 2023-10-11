using UnityEngine;

public class FuseBox : MonoBehaviour
{
    [SerializeField] private Transform fuseLocation;
    [SerializeField] private GameObject matchingFuse;
    [SerializeField] private LightFlicker flickerScript;
    [SerializeField] private Light fuseBoxLight;
    [SerializeField] private GameObject connectedCeilingLight;
    [SerializeField] private AudioSource audioSource;
    private bool invoked = false;

    // Declare the puzzle solved event
    public static event System.Action OnPuzzleSolved;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something collided with fusebox");
        if (other.transform.parent.CompareTag("Fuse"))
        {
            Debug.Log("Fuse collided!");
            CheckFuse(other.transform.parent.gameObject);
        }
    }

    private void CheckFuse(GameObject fuse)
    {
        // Check to see if the fuse in the trigger is the fuse that this box is expecting
        if (fuse == matchingFuse)
        {
            Debug.Log("Correct fuse!");
            if (invoked == false)
            {
                AcceptFuse(fuse);
            }
        }
    }

    private void AcceptFuse(GameObject fuse)
    {
        invoked = true;
        // Takes the matching fuse from the player, sets the parent and the transform
        Rigidbody fuseRB = fuse.GetComponent<Rigidbody>();
        fuseRB.isKinematic = true;
        fuse.transform.position = fuseLocation.position;
        flickerScript.CancelCoroutines();
        fuseBoxLight.enabled = true;
        TurnLightsOn();
        audioSource.Play();
    }

    private void TurnLightsOn()
    {
        // Activates the connected lights and checks the level for completion
        connectedCeilingLight.SetActive(true);
        Debug.Log("Invoking PuzzleSolved.");
        OnPuzzleSolved?.Invoke();
    }
}
