using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeManager : MonoBehaviour
{
    public Button btnPlay,btnCredit ,btnSetting, btnQuit;

    public TransitionSettings transitionSettings;

    public float delayTransiton = 0.01f;

    private void Start()
    {
        btnPlay.onClick.AddListener(PlayClick);
        btnSetting.onClick.AddListener(SettingClick);
        btnQuit.onClick.AddListener(QuitClick);
    }

    public void PlayClick ()
    {
        TransitionManager.Instance().Transition(1 , transitionSettings, delayTransiton);
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
