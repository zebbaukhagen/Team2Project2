using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioClip[] audioClips;// holds the background music
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;

    private int currentAudioIndex = 0;

    private void Awake()
    {
        // Ensure only one instance of AudioManager exists
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
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
        audioSource = GetComponent<AudioSource>();
        PlayNextAudioClip();
    }

    public void PlayNextAudioClip()
    {
        if(currentAudioIndex < audioClips.Length) 
        {
            audioSource.clip = audioClips[currentAudioIndex];
            audioSource.Play();
            currentAudioIndex++;
        }
    }

    public void ClickSound()
    {

    }
}
