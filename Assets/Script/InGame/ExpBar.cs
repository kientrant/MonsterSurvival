using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public Image fillBar;
    public TextMeshProUGUI valueText;

    public static float maxValue;
    public static float currentValue;
    private float percentOfExp = 0;

    public TextMeshProUGUI valueCoin;
    public static int coinPlayer;

    private void Update()
    {
        percentOfExp = (float)currentValue / (float)maxValue * 100;
        fillBar.fillAmount = (float)percentOfExp / (float)100;
        valueText.text = $"{(int)percentOfExp} %";
        valueCoin.text = $"{(int)coinPlayer}";
    }

}
