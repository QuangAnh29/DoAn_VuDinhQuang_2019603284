using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject pause;
    public GameObject instructionsCanvas;

    private void Start()
    {
        
    }


    //Activate game over screen
    public void GameOver()
    {
        pause.SetActive(false);
        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySFX("GameOver");

    }

    //Game over functions

    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    //MainMenu functions
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        SoundManager.instance.musicSource.Stop();
        SoundManager.instance.musicSource.Play();
    }

    //Quit functions
    public void Quit()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
