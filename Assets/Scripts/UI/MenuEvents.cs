using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEvents : MonoBehaviour
{
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
        SoundManager.instance.musicSource.Play();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
