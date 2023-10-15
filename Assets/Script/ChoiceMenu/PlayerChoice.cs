using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChoice : MonoBehaviour
{
    public int index;
    public ValueTranser vT;

    private void Start()
    {
    }

    public void getPlayerClass()
    {
    vT.ClassPlayer = index;
    }

}
