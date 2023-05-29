using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsHandler : MonoBehaviour
{
    public GameObject[] stars;
    private int coinsCount;

    private void Start()
    {
        coinsCount = GameObject.FindGameObjectsWithTag("Cherry").Length;

    }

    public void StarsAcheived()
    {
        int coinsLeft = GameObject.FindGameObjectsWithTag("Cherry").Length;
        int coinsCollected = coinsCount - coinsLeft;
        float percentage = float.Parse(coinsCollected.ToString()) / float.Parse(coinsCount.ToString()) * 100f;

        print(percentage + "%");

        if(percentage > 0f && percentage < 33f)
        {
            //one star
            stars[2].SetActive(true);
        }
        else if(percentage >= 33f && percentage < 100f)
        {
            //two star
            stars[0].SetActive(true);
            stars[1].SetActive(true);
        }
        else if(percentage == 100f)
        {
            //three star
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
    }
}
