using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] skins;
    public int selectedCharacter;
    public Text SumCoinText;

    public Character[] character;

    public Button unlockButton;
    int Coin;

    private void Awake()
    {
        Coin = PlayerPrefs.GetInt("TotalCoin");
        SumCoinText.text = Coin.ToString();
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter", 0);
        foreach(GameObject player in skins)
        {
            player.SetActive(false);
        }

        skins[selectedCharacter].SetActive(true);


        foreach(Character c in character)
        {
            if(c.price == 0)
            {
                c.isUnlocked = true;
            }
            else
            {
                c.isUnlocked = PlayerPrefs.GetInt(c.name, 0) == 0 ? false : true;
            }
        }

        UpdateUI();
    }

    public void ChangeNext()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if(selectedCharacter == skins.Length)
        {
            selectedCharacter = 0;
        }
        skins[selectedCharacter].SetActive(true);
        if (character[selectedCharacter].isUnlocked == true)
            PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        UpdateUI();
    }

    public void ChangePrew()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter == -1)
        {
            selectedCharacter = skins.Length - 1;
        }
        skins[selectedCharacter].SetActive(true);
        if(character[selectedCharacter].isUnlocked == true)
            PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        UpdateUI();
    }

    public void UpdateUI()
    {
        if(character[selectedCharacter].isUnlocked == true)
        {
            unlockButton.gameObject.SetActive(false);
        }
        else
        {
            unlockButton.GetComponentInChildren<Text>().text = "Price: " + character[selectedCharacter].price;
            Coin = PlayerPrefs.GetInt("TotalCoin");
            SumCoinText.text = Coin.ToString();

            if (Coin < character[selectedCharacter].price)
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = false;
            }
            else
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = true;
            }
        }
    }

    public void Unlock()
    {
        Coin = PlayerPrefs.GetInt("TotalCoin");
        int price = character[selectedCharacter].price;
        PlayerPrefs.SetInt("TotalCoin", Coin - price);
        PlayerPrefs.SetInt(character[selectedCharacter].name, 1);
        PlayerPrefs.GetInt("selectedCharacter", selectedCharacter);
        character[selectedCharacter].isUnlocked = true;
        UpdateUI();
    }
}
