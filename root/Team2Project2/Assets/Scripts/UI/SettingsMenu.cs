using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioManager aManager;
    [SerializeField] private AudioMixer audioMixer;
    public int screenWidth = 1920; 
    public int screenHeight = 1080; 
    public bool fullscreen = true;


    //[SerializeField] private TMP_Dropdown resolutionDropdown;

    //Resolution[] resolutions;



    void Start()
    {
        Screen.SetResolution(screenWidth, screenHeight, fullscreen);
        //resolutions = Screen.resolutions;

        //resolutionDropdown.ClearOptions();

        //List<string> options = new List<string>();

        //int currentResolutionIndex = 0;
        //for(int i = 0; i <resolutions.Length; i++)
        //{
        //    string option = resolutions[i].width + "x" + resolutions[i].height;
        //    options.Add(option);

        //    if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
        //    {
        //        currentResolutionIndex = i;
        //    }
        //}

        //resolutionDropdown.AddOptions(options);
        //resolutionDropdown.value = currentResolutionIndex;
        //resolutionDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    //public void SetResolution(int resolutionIndex)
    //{
    //    Resolution resolution = resolutions[resolutionIndex];
    //    Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    //}
}
