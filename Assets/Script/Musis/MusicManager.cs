using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    [Range(1,100)]
    public static int volume;
    //[SerializeField]
    //private AudioClip backGoundMusic;

    private AudioSource audioSource;

    private bool isLoad;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        this.audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        isLoad =  true;
        if (isLoad != true)
        {
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.audioSource.volume = volume;
    }
}
