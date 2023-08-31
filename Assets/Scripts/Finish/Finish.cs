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
    private void Start()
    {
    }

    private void Awake()
    {
        if(finish == null)
        {
            finish = this;
        }
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
    public static void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }

    /*private void CompleteLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }*/
}
