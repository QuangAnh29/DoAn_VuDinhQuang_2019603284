using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuEvents : MonoBehaviour
{
    private bool unlocked;
    public Image unlockedImage;
    public Text textLevel;
    public GameObject[] stars;

    public Sprite starSpite;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.GetInt("UnlockedLevel") < 1)
        {
            PlayerPrefs.SetInt("UnlockedLevel", 1);
            PlayerPrefs.Save(); // Lưu thay đổi vào PlayerPrefs
        }

        UpdateUnlockedStatus(); // Cập nhật trạng thái
    }


    private void Update()
    {
        UpdateLevelImage();
    }

    private void UpdateUnlockedStatus()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel");
        int thisLevel = int.Parse(gameObject.name.Replace("level", ""));

        if (thisLevel <= unlockedLevel)
        {
            unlocked = true;
        }
        else
        {
            unlocked = false;
        }
    }
    private void UpdateLevelImage()
    {
        if (!unlocked)
        {
            unlockedImage.gameObject.SetActive(true);
            textLevel.gameObject.SetActive(false);

            for(int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(false);
            }
        }
        else
        {
            unlockedImage.gameObject.SetActive(false);
            textLevel.gameObject.SetActive(true);

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(true);
            }

            int StarMax = PlayerPrefs.GetInt("lv" + gameObject.name);
            for (int i = 0; i < StarMax; i++)
            {
                stars[i].gameObject.GetComponent<Image>().sprite = starSpite;
            }

        }
    }


    public void LoadLevel(int index)
    {
        if (unlocked)
        {
            SceneManager.LoadScene(index);
            SoundManager.instance.musicSource.Play();
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
