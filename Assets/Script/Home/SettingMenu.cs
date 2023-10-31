using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    [SerializeField]
    private Button apply, exit;

    public GameObject settingMenu;

    // Start is called before the first frame update
    void Start()
    {
        apply.onClick.AddListener(Apply);
        exit.onClick.AddListener(Exit);
    }

    private void Exit()
    {
        settingMenu.SetActive(false);
    }

    private void Apply()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
