using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SwitchTile : MonoBehaviour
{
    [SerializeField] private List<SwitchTile> neighboringTiles = new();
    [SerializeField] private bool activeState;
    [SerializeField] private Material onMaterial;
    [SerializeField] private Material offMaterial;

    private Renderer myRenderer;

    private void Awake()
    {
        myRenderer = GetComponent<Renderer>();
    }

    public bool ActiveState { get; private set; }

    public void ToggleByProximity()
    {
        // toggles state locally only, to be called from another tile.
        ActiveState = !ActiveState;
        ChangeMaterial();
    }

    public void ToggleBySwitch()
    {
        // toggles state from switch, also toggles neighbors
        ActiveState = !ActiveState;
        ChangeMaterial();
        foreach (SwitchTile tile in neighboringTiles)
        {
            tile.ToggleByProximity();
        }
    }

    private void ChangeMaterial()
    {
        if (ActiveState)
        {
            myRenderer.material = onMaterial;
        }
        else if (!ActiveState)
        {
            myRenderer.material = offMaterial;
        }
        else
        {
            Debug.Log("ActiveState error. Can't set material");
        }
    }
}
