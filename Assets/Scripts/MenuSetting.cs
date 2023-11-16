using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSetting : MonoBehaviour
{
    [SerializeField] private GameObject MenuPause;
    [SerializeField] private GameObject SettingMenu;
    [SerializeField] private GameObject Pause;
    public void Setting()
    {
        Time.timeScale = 0f;
        MenuPause.SetActive(false);
        SettingMenu.SetActive(true);
        Pause.SetActive(false);
    }

    public void OK()
    {
        Time.timeScale = 0f;

        MenuPause.SetActive(true);
        SettingMenu.SetActive(false);
    }

    
}
