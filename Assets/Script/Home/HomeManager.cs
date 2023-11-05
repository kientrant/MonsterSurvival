using EasyTransition;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeManager : MonoBehaviour
{
    public Button btnPlay,btnCredit ,btnSetting, btnQuit, btnCreditClose;

    public TransitionSettings transitionSettings;

    public float delayTransiton = 0.01f;

    public GameObject mainMenu;

    public GameObject settingMenu;

    public GameObject creditPanel;

    private void Awake()
    {
        settingMenu.SetActive(false);
        creditPanel.SetActive(false);
    }

    private void Start()
    {
        btnPlay.onClick.AddListener(PlayClick);
        btnSetting.onClick.AddListener(SettingClick);
        btnCredit.onClick.AddListener(CreditClick);
        btnQuit.onClick.AddListener(QuitClick);
        btnCreditClose.onClick.AddListener(CloseCredit);
    }

    private void CloseCredit()
    {
        creditPanel.SetActive(false);
    }

    private void CreditClick()
    {
        creditPanel.SetActive(true);
    }

    public void PlayClick ()
    {
        TransitionManager.Instance().Transition(1 , transitionSettings, delayTransiton);
    }

    public void SettingClick ()
    {
        settingMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void QuitClick()
    {
        Application.Quit();
    }

}
