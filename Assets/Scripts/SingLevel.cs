using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingLevel : MonoBehaviour
{
    private int currentStarNumber = 0;
    public string levelIndex;
    public void PressStarButton(int starNum)
    {
        currentStarNumber = starNum;
        if(currentStarNumber > PlayerPrefs.GetInt("lv" + levelIndex))
        {
            PlayerPrefs.SetInt("lv" + levelIndex, starNum);
            Debug.Log(PlayerPrefs.GetInt("lv" + levelIndex, starNum));
        }
    }
}
