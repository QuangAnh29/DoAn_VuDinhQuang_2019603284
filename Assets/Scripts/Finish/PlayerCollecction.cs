using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerCollecction : MonoBehaviour
{
    public Text ScoreText;
    public Text CoinText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            EndGame.endGame.EndGamehMenu(ScoreText.text);
            int cherryCount = PlayerPrefs.GetInt("CherryCount", 0); // Lấy số cherry từ PlayerPrefs
            int coinFromCherry = cherryCount * 10; // Tính số coin từ số cherry

            int totalCoin = PlayerPrefs.GetInt("TotalCoin", 0); // Lấy tổng số coin từ PlayerPrefs
            totalCoin += coinFromCherry; // Cộng thêm coin từ level hiện tại vào tổng coin

            PlayerPrefs.SetInt("TotalCoin", totalCoin);
        }

    }
}
