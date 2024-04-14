using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject finishScreen;
    [SerializeField] private GameObject buttonPause;
    public static Finish finish;
    public Text ScoreTextFinish;
    public Text ScoreCoinFinish;

    private void Awake()
    {
        if(finish == null)
        {
            finish = this;
        }
        int coin = PlayerPrefs.GetInt("TotalCoin", 0); // Lấy số coin từ PlayerPrefs
        ScoreCoinFinish.text =  coin.ToString();
    }

    public void FinishMenu(string scores)
    {
        buttonPause.SetActive(false);
        SoundManager.instance.PlaySFX("FinishGame");
        SoundManager.instance.musicSource.Stop();
        Time.timeScale = 0f;
        finishScreen.SetActive(true);
        ScoreTextFinish.text = scores;
        GetComponent<StarsHandler>().StarsAcheived();
        UnlockNextLevel();
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SoundManager.instance.musicSource.Play();
    }
    public void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SoundManager.instance.musicSource.Play();
    }

    public void UnlockNextLevel()
    {

        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1); // Sử dụng 1 làm giá trị mặc định nếu không có giá trị được lưu trữ

        if (currentLevel >= unlockedLevel)
        {
            PlayerPrefs.SetInt("UnlockedLevel", currentLevel + 1);
            PlayerPrefs.Save(); 
        }

    }

}
