using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectableScore : MonoBehaviour
{
    public static int CoinCount;
    public GameObject CoinCountDisplay;
    public GameObject CoinEndDisplay;

    void Start()
    {
        CoinCount = PlayerPrefs.GetInt("coins");
    }

    // Update is called once per frame
    void Update()
    {
        CoinCountDisplay.GetComponent<TMP_Text>().text = "" + CoinCount;
        CoinEndDisplay.GetComponent<TMP_Text>().text = "" + CoinCount;
        PlayerPrefs.SetInt("coins", CoinCount);
    }
}
