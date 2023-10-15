using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    public TextMeshProUGUI valueText;
    public static int Level;

    private void Update()
    {
        valueText.text = Level.ToString();
    }
}
