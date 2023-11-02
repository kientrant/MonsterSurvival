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
    public PlayerData currentPlayer;
    private Transform playerSpawnPoint;

    private string SceneName = "MainGameScene";

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
        currentPlayer = playerDatas[vT.ClassPlayer - 1];
        PlayerController.playerData = currentPlayer;

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
            ToggleUpgarde();
        } else
        {
            unToggleUpgarde();
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
        }
        if (Time.timeScale == 0f) {
            Time.timeScale = 1f;
            infoUI.SetActive(true);
            pauseUI.SetActive(false);
            isPause = false;
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
        SceneManager.LoadScene(this.SceneName);
    }

    public void Resume ()
    {
        TogglePause();
    }

    public void Quit2Menu()
    {
        //main menu
        SceneManager.LoadScene(0);
    }

}
