using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private DoorStatus doorStatus;

    private void Awake()
    {
        if (!TryGetComponent(out animator)) { Debug.Log("No animator found"); }
        SetBeginningDoorStatus();
    }

    private void SetBeginningDoorStatus()
    {
        if (doorStatus == DoorStatus.OPEN)
        {
            animator.SetTrigger("DoorOpened");
        }
    }

    public void ToggleDoor()
    {
        if (doorStatus == DoorStatus.OPEN)
        {
            doorStatus = DoorStatus.CLOSED;
            animator.SetTrigger("DoorClosed");
        }
        else if (doorStatus == DoorStatus.CLOSED)
        {
            doorStatus = DoorStatus.OPEN;
            animator.SetTrigger("DoorOpened");
        }
    }

    public void SetDoorStatus(DoorStatus status)
    {
        if (status == DoorStatus.OPEN)
        {
            doorStatus = DoorStatus.OPEN;
            animator.SetTrigger("DoorOpened");
        }
        else if (status == DoorStatus.CLOSED)
        {
            doorStatus = DoorStatus.CLOSED;
            animator.SetTrigger("DoorClosed");
        }
    }
}



public enum DoorStatus
{
    OPEN,
    CLOSED
}