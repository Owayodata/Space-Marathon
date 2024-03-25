using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharSelection : MonoBehaviour
{
    
    [Header("Char Attirbutes")]
    private int currentChar;
    [SerializeField] private int[] charPrices;

    [Header ("Navigation Buttons")]
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;

    [Header("Play/Buy Buttons")]
    [SerializeField] private Button Play;
    [SerializeField] private Button Buy;
    [SerializeField] private TMP_Text priceText;

    private void Start()
    {
        currentChar = SaveManager.instance.currentChar;
        selectChar(currentChar);
    }
    private void selectChar(int _index)
    {
        leftButton.interactable = (_index != 0);
        rightButton.interactable = (_index != transform.childCount - 1);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (SaveManager.instance.charsUnlocked[currentChar])
        {
            Play.gameObject.SetActive(true);
            Buy.gameObject.SetActive(false);
        }
        else
        {
            Play.gameObject.SetActive(false);
            Buy.gameObject.SetActive(true);
            priceText.text = charPrices[currentChar] + "";

            //check if there is enough money
        }
    }

    private void Update()
    {
       
        //check if we have enough money
        if (Buy.gameObject.activeInHierarchy)
        {
            Buy.interactable = (SaveManager.instance.CoinCount >= charPrices[currentChar]);
        }
        
    }

    public void changeChar(int _change)
    {
        currentChar += _change;
        currentChar = Mathf.Clamp(currentChar, 0, transform.childCount - 1);
        selectChar(currentChar);
        SaveManager.instance.currentChar = currentChar;
        SaveManager.instance.Save();

    }

    public void buyChar()
    {

        SaveManager.instance.CoinCount -= charPrices[currentChar];
        SaveManager.instance.charsUnlocked[currentChar] = true;
        SaveManager.instance.Save();
        UpdateUI();
    }

}
