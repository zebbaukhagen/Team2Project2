using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioClip[] backGroundClips;// holds the background music
    [SerializeField] private AudioClip[] audioClips;
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
            clickSound = GetComponent<AudioSource>();
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
        PlayNextAudioClip();
    }

    public void PlayNextAudioClip()
    {
        if (currentAudioIndex < backGroundClips.Length)
        {
            backGroundMusic.clip = backGroundClips[currentAudioIndex];
            backGroundMusic.Play();
            currentAudioIndex++;
        }
    }


    public void ClickSound()
    {
       clickSound.clip = audioClips[0];
       clickSound.Play();
        
    }
}
