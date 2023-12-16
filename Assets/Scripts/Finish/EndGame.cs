using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject finishScreen;
    [SerializeField] private GameObject buttonPause;
    public static EndGame endGame;
    public Text ScoreTextFinish;
    public Text ScoreCoinFinish;
    private void Start()
    {
    }

    private void Awake()
    {
        if (endGame == null)
        {
            endGame = this;
        }

        int coin = PlayerPrefs.GetInt("TotalCoin", 0); // Lấy số coin từ PlayerPrefs
        ScoreCoinFinish.text = coin.ToString();
    }

    public void EndGamehMenu(string scores)
    {
        buttonPause.SetActive(false);
        SoundManager.instance.PlaySFX("FinishGame");
        SoundManager.instance.musicSource.Stop();
        Time.timeScale = 0f;
        finishScreen.SetActive(true);
        ScoreTextFinish.text = scores;
        GetComponent<StarsHandler>().StarsAcheived();
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
}
