using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingGame : MonoBehaviour
{
    [SerializeField] List<GameObject> listOfPanels = new();
    int panelListCount;

    // Start is called before the first frame update
    void Start()
    {
        panelListCount = listOfPanels.Count;
        if (panelListCount > 0)
        {
            StartCoroutine(IntroSceneTransition());
        }
        else
        {
            GameManager.instance.NextLevel();
        }

    }

    private IEnumerator IntroSceneTransition()
    {
        foreach (GameObject panel in listOfPanels)
        {
            panel.SetActive(true);
            yield return new WaitForSeconds(1.25f);
            panel.SetActive(false);
        }
        GameManager.instance.NextLevel();
    }
}