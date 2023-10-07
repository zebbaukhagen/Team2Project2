using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource[] audioSources;// holds the background music
    

    private int currentAudioIndex = 0;

    private void Awake()
    {
        // Ensure only one instance of AudioManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayNextAudioSource();
    }

    public void PlayNextAudioSource()
    {
        if(currentAudioIndex < audioSources.Length) 
        {
            audioSources[currentAudioIndex].Play();
            currentAudioIndex++;
        }
    }
}
