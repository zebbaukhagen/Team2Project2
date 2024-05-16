using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SetLevelCompleted();
            GameManager.instance.NextLevel();
        }
    }

    private void Respawn()
    {
        gameObject.transform.position = respawnPoint.position;
    }

    public void SetLevelCompleted()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        GameManager.instance.MarkPuzzleComplete(currentScene - 3);
        Debug.Log("Calling SetLevelCompleted on level: " + currentScene);
    }
}
