using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class MainGame : MonoBehaviour
{
    [SerializeField]
    private GameObject[] player;
    public int frameRate = 60;

    private void Awake()
    {
        Application.targetFrameRate = frameRate;
    }

    // Start is called before the first frame update
    void Start()
    {
        Transform playerSpawnPoint = GameObject.Find("PlayerSpawnPoint").transform;
        Instantiate(player[0], playerSpawnPoint.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
