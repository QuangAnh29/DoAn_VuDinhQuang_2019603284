using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollect : MonoBehaviour
{
    //[SerializeField] private GameObject finishScreen;

    public Text ScoreText;
    public Text CoinText;
    [SerializeField] private AudioClip finishAudio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            /*Finish.UnlockNewLevel();*/
            Finish.finish.FinishMenu(ScoreText.text);
            //SoundManager.instance.PlaySound(finishAudio);
            int cherryCount = PlayerPrefs.GetInt("CherryCount", 0); // Lấy số cherry từ PlayerPrefs
            int coinFromCherry = cherryCount * 10; // Tính số coin từ số cherry

            int totalCoin = PlayerPrefs.GetInt("TotalCoin", 0); // Lấy tổng số coin từ PlayerPrefs
            totalCoin += coinFromCherry; // Cộng thêm coin từ level hiện tại vào tổng coin

            PlayerPrefs.SetInt("TotalCoin", totalCoin);
        }
        
    }



}
