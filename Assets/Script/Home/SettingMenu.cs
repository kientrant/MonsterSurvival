using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    [SerializeField]
    private Button apply, exit;

    public GameObject settingMenu, mainMenu;

    [SerializeField]
    private Slider vMusic, vSound;

    private float vMusicValue, vSoundValue; 

    [SerializeField]
    public TMP_Dropdown myDropdown;
    //0 1080
    //1 1600
    //2 1366
    private int resValue = 0;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        apply.onClick.AddListener(Apply);
        exit.onClick.AddListener(Exit);
        myDropdown.onValueChanged.AddListener(resChange);
        vMusic.onValueChanged.AddListener(vMusisChange);
        vSound.onValueChanged.AddListener(vSoundChange);
        vSound.value =  (int) PlayerPrefs.GetFloat("vSound", vSoundValue);
        vMusic.value = (int)PlayerPrefs.GetFloat("vMusic", vMusicValue);
        vMusicValue = (int)PlayerPrefs.GetFloat("vSound", vSoundValue);
        MusicManager.volume = (int)PlayerPrefs.GetFloat("vMusic", vMusicValue);
    }

    void vMusisChange(float musicV)
    {
        vMusicValue = musicV;
        MusicManager.volume = (int)vMusicValue;
    }

    void vSoundChange(float soundV)
    {
        vSoundValue = soundV;
        PlayerController.soundV = (int) vSoundValue;
    }

    void resChange(int res)
    {
        resValue = (int) res;
    }

    void LateUpdate()
    {
        resValue = myDropdown.value;
    }

    void SaveSetting()
    {
        PlayerPrefs.SetFloat("vMusic", vMusicValue);
        PlayerPrefs.SetFloat("vSound", vSoundValue);
        PlayerPrefs.SetInt("resValue", resValue);
    }

    private void Exit()
    {
        settingMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    private void Apply()
    {
        int widthC , heightC ;
        bool isFullscreen;
        switch (resValue)
        {
            case 0:
                heightC = 1080;
                widthC = 1920;
                isFullscreen = true;
                break;
            case 1:
                heightC = 900;
                widthC = 1600;
                isFullscreen = false;
                break;
            case 2:
                heightC = 768;
                widthC = 1366;
                isFullscreen = false;
                break;
            default:
                heightC = 1080;
                widthC = 1920;
                isFullscreen = true;
                break;
        }
        Screen.SetResolution(widthC, heightC, isFullscreen);
        SaveSetting();

    }
}
