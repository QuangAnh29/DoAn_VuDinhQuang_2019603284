using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject pause;
    public GameObject instructionsCanvas;

    public void GameOver()
    {
        pause.SetActive(false);
        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySFX("GameOver");

    }

    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        SoundManager.instance.musicSource.Stop();
        SoundManager.instance.musicSource.Play();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
