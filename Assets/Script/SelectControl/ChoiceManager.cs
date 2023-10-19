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
        if (vT.ClassPlayer != 0 && vT.ClassPlayer != 0)
        {
            TransitionManager.Instance().Transition(2, transitionSettings, delayTransiton);
        }
        
    }
}
