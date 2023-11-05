using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainGame : MonoBehaviour
{
    [SerializeField]
    private GameObject[] player;
    [SerializeField]
    private GameObject[] maps;
    [SerializeField]
    private GameObject PlayerParent;
    [SerializeField]
    private ValueTranser vT;
    public int frameRate = 120;

    public GameObject infoUI, pauseUI, upgradeUI;
    public Button reset, resume, quit2menu;
    public static bool isUpgrade = false;
    public static bool isPause = false;
    public static bool isGameOver = false;

    public PlayerData[] playerDatas;
    private PlayerData currentPlayer;
    private Transform playerSpawnPoint;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerSpawnPoint = GameObject.Find("PlayerSpawnPoint").transform;
        GameObject go = Instantiate(player[vT.ClassPlayer - 1], playerSpawnPoint.position, Quaternion.identity);
        currentPlayer = playerDatas[vT.ClassPlayer - 1];
        PlayerController.playerData = currentPlayer;

        //go.transform.parent = PlayerParent.transform;

        pauseUI.SetActive(false);
        upgradeUI.SetActive(false);
        infoUI.SetActive(true);
    }

    // Update is called once per frame
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        if (isUpgrade)
        {
            ToggleUpgarde();
        }
        else
        {
            unToggleUpgarde();
        }
    }

    private void TogglePause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f;
            infoUI.SetActive(false);
            pauseUI.SetActive(true);
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1f;
            infoUI.SetActive(true);
            pauseUI.SetActive(false);
            isPaused = false;
        }
    }

    public void ToggleUpgarde()
    {
        Time.timeScale = 0f;
        infoUI.SetActive(false);
        upgradeUI.SetActive(true);
        isPause = true;
    }

    public void unToggleUpgarde()
    {
        Time.timeScale = 1f;
        infoUI.SetActive(true);
        upgradeUI.SetActive(false);
        isPause = false;
    }

    public virtual void Reset ()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void Resume ()
    {
        isPaused = false; // Set isPaused to true before resuming
        TogglePause();
    }

    public void Quit2Menu()
    {
        //main menu
        SceneManager.LoadScene(0);
    }

}
