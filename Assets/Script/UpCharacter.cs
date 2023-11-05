using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class UpCharacter : MonoBehaviour
{
    [SerializeField ] private PlayerData character;
    private int levelCharacter;
    private int coin;
    [SerializeField] private TextMeshProUGUI coinDisplay;

    public void upLevel()
    {
        coin = PlayerPrefs.GetInt("Coin");
        if (coin > 2000)
        {
            upStat();
            coin -= 2000;
        }
        PlayerPrefs.SetInt("Coin", coin);
    }

    private void upStat()
    {
        var eHeart = character.Heart;
        character.Heart += Mathf.CeilToInt(eHeart * 0.2f);

        var eDepend = character.Depend;
        character.Depend -= Mathf.Ceil(0.2f * eDepend);

        //3
        var eStrength = character.Strength;
        character.Strength += Mathf.Ceil(eStrength * 0.2f);

        //4
        var eDexterity = character.Dexterity;
        character.Dexterity += Mathf.Ceil(eDexterity * 0.2f);


        var eFireCoolDown = character.attackCoolDown;
        character.attackCoolDown -= Mathf.Ceil(eFireCoolDown * 0.2f);

        //6

        var eSkillCollDown = character.skillCoolDown;
        character.skillCoolDown -= Mathf.Ceil(eSkillCollDown * 0.2f);

        //7

        var eSkillSize = character.SizeOfSkill;
        character.SizeOfSkill += Mathf.Ceil(eSkillSize * 0.2f);


        var eSkillDamage = character.StrengthOfSkill;
        character.StrengthOfSkill += Mathf.Ceil(eSkillDamage * 0.2f);
    }

    // Start is called before the first frame update
    void Start()
    {
        coin = PlayerPrefs.GetInt("Coin");
    }

    // Update is called once per frame
    void Update()
    {
        coinDisplay.text = coin.ToString();
    }
}
