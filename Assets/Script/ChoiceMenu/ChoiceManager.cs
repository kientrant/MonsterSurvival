using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceManager : MonoBehaviour
{
    public ValueTranser vT;
    public void Play()
    {
        if (vT.ClassPlayer != 0 && vT.ClassPlayer != 0)
        {
            SceneManager.LoadScene(2);
        }
        
    }
}
