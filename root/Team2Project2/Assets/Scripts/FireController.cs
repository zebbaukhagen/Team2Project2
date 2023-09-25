using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps; // set in editor
    [SerializeField] private GameObject hitBox; // set in editor
    private SwitchPuzzle parentPuzzle;
    [SerializeField] private bool particleSystemActive;

    private void Awake()
    {
        parentPuzzle = GetComponentInParent<SwitchPuzzle>();
        parentPuzzle.AddChildFireToList(this);
        particleSystemActive = ps.isPlaying;
    }

    public void ToggleParticleSystem()
    {
        if (particleSystemActive)
        {
            particleSystemActive = !particleSystemActive;
            ps.Stop();
            hitBox.SetActive(false);
        }
        else
        {
            particleSystemActive = !particleSystemActive;
            ps.Play();
            hitBox.SetActive(true);
        }
    }
}
