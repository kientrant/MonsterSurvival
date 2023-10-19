using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

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

    public GameObject infoUI, pauseUI, upgradeUI, gameOverUI;
    public static bool isUpgrade = false;
    public static bool isPause = false;

    public PlayerData[] playerDatas;
    private Transform playerSpawnPoint;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        playerSpawnPoint = GameObject.Find("PlayerSpawnPoint").transform;
        //LoadMap(1);
        GameObject go = Instantiate(player[vT.ClassPlayer - 1], playerSpawnPoint.position, Quaternion.identity);
        PlayerController.playerData = playerDatas[vT.ClassPlayer - 1];

        //go.transform.parent = PlayerParent.transform;

        pauseUI.SetActive(false);
        upgradeUI.SetActive(false);
        infoUI.SetActive(true);
        gameOverUI.SetActive(false);
    }

    private async void LoadMap(int map_index)
    {
        GameObject map = Instantiate(maps[vT.MapName - 1], playerSpawnPoint.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        if (isUpgrade)
        {
            ToggleUpgrade();
        }

    }

    private void TogglePause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0f;
            infoUI.SetActive(false);
            pauseUI.SetActive(true);
            isPause = true;
        } else if (Time.timeScale == 0) {
            Time.timeScale = 1f;
            infoUI.SetActive(true);
            pauseUI.SetActive(false);
            isPause = false;
        }

    }

    private void ToggleUpgrade()
    {

    }

}
