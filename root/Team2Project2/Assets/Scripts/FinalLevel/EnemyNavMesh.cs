using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

// Make sure that these objects have a navMeshAgent.
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyNavMesh : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets = new();
    [SerializeField] private GameObject target;

    private NavMeshAgent agent;

    private readonly float distanceThreshold = 1f;
    private readonly float checkInterval = 0.1f; // Ten times per second.
    //private readonly float sightDistance = 5f;
    private int destinationListLength;
    private int destinationCounter;

    // Start is called before the first frame update.
    void Start()
    {
        // Reference this navMeshAgent.
        agent = GetComponent<NavMeshAgent>();
        // Count list and convert to 0 based counting.
        destinationListLength = targets.Count - 1;
        ReleaseEnemy();
    }

    // Update is called once per frame.
    void Update()
    {
        if (agent.pathStatus == NavMeshPathStatus.PathPartial || agent.pathStatus == NavMeshPathStatus.PathInvalid)
        {
            agent.SetDestination(target.transform.position);
        }
    }

    public void ReleaseEnemy()
    {
        target = targets[0];
        // Tell navMeshAgent to start pathing.
        agent.SetDestination(target.transform.position);
        // Start checking if at the target.
        StartCoroutine(CheckIfAtTarget());
    }

    private IEnumerator CheckIfAtTarget()
    {
        // Always check if the current position matches that of the target.
        while (true)
        {
            // Calculate distance to target.
            float distanceToTarget = Vector3.Distance(gameObject.transform.position, target.transform.position);

            // If within threshold.
            if (distanceToTarget < distanceThreshold)
            {
                // Change target to the other destination.
                SwitchDestinations();
            }

            yield return new WaitForSeconds(checkInterval);
        }
    }

    private void SwitchDestinations()
    {
        // Loop through the list of target locations and set them in turn. 
        destinationCounter++;
        if (destinationCounter > destinationListLength)
        {
            destinationCounter = 0;
            target = targets[0];
        }
        else
        {
            target = targets[destinationCounter];
        }
        agent.SetDestination(target.transform.position);
        // Debug.Log($"Switched target to: {target.name}");
    }
}