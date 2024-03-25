using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinShow : MonoBehaviour
{
    private int CoinCount;
    public GameObject CoinCurrencyDisplay;
    // Start is called before the first frame update
    void Awake()
    {
        
        CoinCount = PlayerPrefs.GetInt("coins", 0);
        UpdateCoinDisplay();

    }

    // Update is called once per frame
    void Update()
    {

        //CoinCount = CollectableScore.CoinCount;
        if (CoinCount != PlayerPrefs.GetInt("coins", 0))
        {
            
            CoinCount = PlayerPrefs.GetInt("coins", 0);
            
            UpdateCoinDisplay();
        }

    }

    private void UpdateCoinDisplay()
    {
        CoinCurrencyDisplay.GetComponent<TMP_Text>().text = CoinCount.ToString();
    }
}
