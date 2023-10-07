using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeManager : MonoBehaviour
{
    public Button btnPlay, btnSetting, btnQuit;

    private void Start()
    {
        btnPlay.onClick.AddListener(PlayClick);
        btnSetting.onClick.AddListener(SettingClick);
        btnQuit.onClick.AddListener(QuitClick);
    }

    public void PlayClick ()
    {
        SceneManager.LoadScene(1);
    }

    public void SettingClick ()
    {
        Debug.Log("Setting");
    }
    public void QuitClick()
    {
        Application.Quit();
    }

}
