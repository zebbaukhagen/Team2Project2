using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioClip[] audioClips;// holds the background music
    [SerializeField] private AudioSource[] audioSource;
     private int currentAudioIndex = 0;
    private bool isGameStarted = false;

    private void Awake()
    {
        // Ensure only one instance of AudioManager exists
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource[]>();
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
        if (isGameStarted)
            PlayNextAudioClip();
        else
            isGameStarted = true;
    }

    public void PlayNextAudioClip()
    {
        if (currentAudioIndex < audioClips.Length && audioSource.Length > 0)
        {
            audioSource[0].clip = audioClips[currentAudioIndex];
            audioSource[0].Play();
            currentAudioIndex++;
        }
    }


    public void ClickSound()
    {
        if (isGameStarted)
        {
            audioSource[1].clip = audioClips[currentAudioIndex];
            audioSource[1].Play();
        }
    }
}
