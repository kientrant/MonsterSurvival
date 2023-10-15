using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeartBar : MonoBehaviour
{

    public Image fillBar;

    public TextMeshProUGUI valueText;

    public static float currentValue;
    public static float maxValue;


    private void Update()
    {
        fillBar.fillAmount = (float)currentValue / (float)maxValue;
        valueText.text = currentValue.ToString() + " / " + maxValue.ToString();
    }
}
