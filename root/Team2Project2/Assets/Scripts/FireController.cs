using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps; // set in editor
    [SerializeField] private GameObject hitBox; // set in editor
    private SwitchPuzzle parentPuzzle;
    private bool particleSystemActive = true;

    private void Awake()
    {
        parentPuzzle = GetComponentInParent<SwitchPuzzle>();
        parentPuzzle.AddChildFireToList(this);
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
