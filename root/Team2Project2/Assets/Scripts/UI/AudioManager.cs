using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioClip[] audioClips;// holds the background music
    [SerializeField] private AudioSource backGroundMusic;
    [SerializeField] private AudioSource clickSound;
    private int currentAudioIndex = 0;

    private void Awake()
    {
        // Ensure only one instance of AudioManager exists
        if (instance == null)
        {
            instance = this;
            backGroundMusic = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static AudioManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
 
    }

    public void PlayNextAudioClip()
    {
        if (currentAudioIndex < 1)
        {
            backGroundMusic.clip = audioClips[currentAudioIndex];
            backGroundMusic.Play();
            currentAudioIndex++;
        }
    }


    public void ClickSound()
    {
       clickSound.clip = audioClips[2];
       clickSound.Play();
        
    }
}
