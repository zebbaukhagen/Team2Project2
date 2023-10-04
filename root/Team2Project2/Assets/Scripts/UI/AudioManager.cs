using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource audioSource2;
    [SerializeField] private UILevelController uiController;

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
        audioSource = GetComponent<AudioSource>();
        PlayMusic();
        audioSource2.Stop();
    }

    public void PlayMusic()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    //void MainGameMusic()
    //{
    //    if(uiController.NextLevel)
    //    {
    //        audioSource.Stop();
    //        audioSource2.Play();
    //    }
    //}

  

    //public void PauseAudio()
    //{
    //    if (audioSource.isPlaying)
    //    {
    //        audioSource.Pause(); // Pause the audioManager if it's playing
    //    }
    //}
}
