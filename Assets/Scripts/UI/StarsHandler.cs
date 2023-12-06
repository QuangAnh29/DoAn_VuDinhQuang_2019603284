using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StarsHandler : MonoBehaviour
{
    public GameObject[] stars;
    private int coinsCount;

    private int currentStarNumber = 0;
    public string levelIndex;
    private void Start()
    {
        coinsCount = GameObject.FindGameObjectsWithTag("Cherry").Length;

    }

    public void StarsAcheived()
    {
        int starsEarned = 0;
        int coinsLeft = GameObject.FindGameObjectsWithTag("Cherry").Length;
        int coinsCollected = coinsCount - coinsLeft;
        float percentage = float.Parse(coinsCollected.ToString()) / float.Parse(coinsCount.ToString()) * 100f;

        print(percentage + "%");

        if(percentage > 0f && percentage < 33f)
        {
            //one star
            stars[2].SetActive(true);
            starsEarned = 1;
        }
        else if(percentage >= 33f && percentage < 100f)
        {
            //two star
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            starsEarned = 2;
        }
        else if(percentage == 100f)
        {
            //three star
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            starsEarned = 3;
        }

        PressStarButton(starsEarned);
    }

    private void PressStarButton(int starNum)
    {
        currentStarNumber = starNum;
        if (currentStarNumber > PlayerPrefs.GetInt("lv" + levelIndex))
        {
            PlayerPrefs.SetInt("lv" + levelIndex, starNum);
            Debug.Log(PlayerPrefs.GetInt("lv" + levelIndex, starNum));
        }
    }

    /*private void UpdateStars(int starsEarned)
    {
        PlayerPrefs.SetInt("level" + SceneManager.GetActiveScene().buildIndex, starsEarned);
        PlayerPrefs.Save();
    }*/
}
