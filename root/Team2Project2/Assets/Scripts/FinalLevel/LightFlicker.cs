using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class LightFlicker : MonoBehaviour
{
    /// <summary>
    /// This class can be attached to a light in the editor and will automatically toggle it on and off at
    /// semi-random intervals. It comes pre-initialized with working values, but the flickerTime can be modified in the editor.
    /// </summary>
    private Light _light;
    [SerializeField] private float[] flickerTime;
    private void Awake()
    {
        _light = GetComponent<Light>();
        flickerTime = new float[2] { 0.5f, 1.5f };  // Example values.
    }

    private void Start()
    {
        StartCoroutine(FlickerLights());
    }

    private IEnumerator FlickerLights()
    {
        if (flickerTime.Length < 2)
        {
            Debug.LogError("flickerTime array not properly initialized. It should contain at least two elements.");
            yield break;  // Exit the coroutine.
        }

        while (true)
        {
            // Toggles the light on and off.
            _light.enabled = false;
            yield return new WaitForSeconds(Random.Range(flickerTime[0], flickerTime[1]));
            _light.enabled = true;
            yield return new WaitForSeconds(Random.Range(flickerTime[0], flickerTime[1]));
        }
    }

    public void CancelCoroutines()
    {
        StopCoroutine(FlickerLights());
    }
}