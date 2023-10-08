using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] private UILevelController uiLevelController;

    [SerializeField] Transform respawnPoint;
    private void Awake()
    {
        respawnPoint = GameObject.Find("Respawn").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillBox"))
        {
            Debug.Log("Player ate shit");
            Respawn();
        }
        else if(other.CompareTag("LevelExit"))
        {
            GameManager.instance.NextLevel();
        }
    }

    private void Respawn()
    {
        gameObject.transform.position = respawnPoint.position;
    }
}
