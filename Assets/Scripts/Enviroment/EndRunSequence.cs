using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRunSequence : MonoBehaviour
{
    public GameObject liveCoins;
    public GameObject liveDis;
    public GameObject endScreen;
    public GameObject fadeOut;
    public GameObject hud;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(endSequence());
    }

    IEnumerator endSequence()
    {
        yield return new WaitForSeconds(5);
        liveCoins.SetActive(false);
        hud.SetActive(false);
        liveDis.SetActive(false);
        endScreen.SetActive(true);
        yield return new WaitForSeconds(5);
        fadeOut.SetActive(true);
    }
}
