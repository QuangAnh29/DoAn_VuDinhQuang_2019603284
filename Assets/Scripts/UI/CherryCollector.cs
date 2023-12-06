using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CherryCollector : MonoBehaviour
{
    private int totalCherries; // Số lượng cherry trong cấp độ
    private int cherriesCollected; // Số lượng cherry đã thu thập

    void Start()
    {
        totalCherries = GameObject.FindGameObjectsWithTag("Cherry").Length;
        cherriesCollected = 0;
    }

    // Hàm này được gọi khi thu thập được cherry
    public void CollectCherry()
    {
        cherriesCollected++;

        // Kiểm tra nếu đã thu thập đủ cherry
        if (cherriesCollected <= totalCherries)
        {
            FinishLevel();
        }
    }

    // Hàm xử lý việc hoàn thành cấp độ và tính toán số sao
    private void FinishLevel()
    {
        int starsEarned = 0;

        float collectedPercentage = (float)cherriesCollected / (float)totalCherries * 100f;

        if (collectedPercentage >= 100f)
        {
            starsEarned = 3;
        }
        else if (collectedPercentage >= 50f)
        {
            starsEarned = 2;
        }
        else if (collectedPercentage >= 25f)
        {
            starsEarned = 1;
        }

  

        UpdateStars(starsEarned);
    }

    // Hàm gọi để cập nhật số sao đã kiếm được
    private void UpdateStars(int starsEarned)
    {
        PlayerPrefs.SetInt("level" + SceneManager.GetActiveScene().buildIndex, starsEarned);
        PlayerPrefs.Save();
    }
}
