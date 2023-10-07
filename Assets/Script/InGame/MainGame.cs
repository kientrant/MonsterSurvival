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
    private GameObject PlayerParent; 
    public int frameRate = 60;
    public GameObject infoUI, pauseUI, upgradeUI;
    private bool isPlaying,isUpgrade = false;

    private void Awake()
    {
        Application.targetFrameRate = frameRate;
    }

    // Start is called before the first frame update
    void Start()
    {
        Transform playerSpawnPoint = GameObject.Find("PlayerSpawnPoint").transform;
        GameObject go = Instantiate(player[0], playerSpawnPoint.position, Quaternion.identity);

        go.transform.parent = PlayerParent.transform;

        pauseUI.SetActive(false);
        upgradeUI.SetActive(false);
        infoUI.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPlaying)
            {
                PauseGame();
                UIPauseActive();
            }
            else
            {
                ResumeGame();
            }
        }
            

        if (isUpgrade)
        {
            PauseGame();
            upgradeActive();
        }
        else
        {
            upgradeDeActive();
            ResumeGame();
        }

    }

    private void UIPauseActive()
    {
        infoUI.SetActive(false);
        pauseUI.SetActive(true);
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        isPlaying = false;
    }
    private void ResumeGame()
    {
        Time.timeScale = 1;
        infoUI.SetActive(true);
        pauseUI.SetActive(false);
        upgradeUI.SetActive(false);
        isPlaying = true;
    }

    private void upgradeActive()
    {
        isUpgrade = true;
        upgradeUI.SetActive(true);
    }

    private void upgradeDeActive()
    {
        isUpgrade = false;
        upgradeUI.SetActive(false);
    }
}
