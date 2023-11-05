using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceManager : MonoBehaviour
{
    public ValueTranser vT;

    public TransitionSettings transitionSettings;

    public float delayTransiton = 0.01f;

    public void Play()
    {
        if (vT.ClassPlayer != 0 && vT.MapName != 0)
        {
            //load scene theo  map choi
            TransitionManager.Instance().Transition(vT.MapName + 1, transitionSettings, delayTransiton);
        }

    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
