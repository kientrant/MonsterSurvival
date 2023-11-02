using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.PlayerLoop.EarlyUpdate;

public class UpgradeController : MonoBehaviour
{
    public int upgradeIndex;

    public GameObject UpgradeUI;
    public static bool UpgradeOpen;
    public GameObject item_1;
    public GameObject item_2;
    public GameObject item_3;
    public static int indexSelect;

    private List<Upgrade> baseUpgrades = new List<Upgrade>();

    private List<Upgrade> upgrades = new List<Upgrade>();

    private Color commonColor = Color.white;
    private Color rareColor = new Color(0f, 255f, 128f); // Light blue
    private Color epicColor = new Color(0f, 128f, 64f); // Darker blue
    private Color legendaryColor = new Color(163f, 53f, 238f); // Purple

    private bool runOnce = false;

    private void Start()
    {
        //Damage
        Upgrade damage5 = new Upgrade("Damage +5%", Upgrade.TypeUpgrade.Strength, "text", 0.05f, 20);
        Upgrade damage10 = new Upgrade("Damage +10%", Upgrade.TypeUpgrade.Strength, "text", 0.1f, 10);
        Upgrade damage20 = new Upgrade("Damage +20%", Upgrade.TypeUpgrade.Strength, "text", 0.2f, 5);
        Upgrade damage30 = new Upgrade("Damage +30%", Upgrade.TypeUpgrade.Strength, "text", 0.3f, 1);

        //Heath
        Upgrade heath5 = new Upgrade("Heath +5%", Upgrade.TypeUpgrade.Heart, "text", 0.05f, 20);
        Upgrade heath10 = new Upgrade("Heath +10%", Upgrade.TypeUpgrade.Heart, "text", 0.1f, 10);
        Upgrade heath15 = new Upgrade("Heath +15%", Upgrade.TypeUpgrade.Heart, "text", 0.15f, 5);
        Upgrade heath20 = new Upgrade("Heath +20%", Upgrade.TypeUpgrade.Heart, "text", 0.2f, 1);

        //Exp
        Upgrade expMutiple2 = new Upgrade("Douple Exp", Upgrade.TypeUpgrade.ExpMulti, "text", 2f, 2);
        Upgrade expMutiple3 = new Upgrade("Triple Exp", Upgrade.TypeUpgrade.ExpMulti, "text", 3f, 2);

        //Depend
        Upgrade depend5 = new Upgrade("Depend +5%", Upgrade.TypeUpgrade.Depend, "text", 0.05f, 20);
        Upgrade depend10 = new Upgrade("Depend +10%", Upgrade.TypeUpgrade.Depend, "text", 0.1f, 10);
        Upgrade depend20 = new Upgrade("Depend +20%", Upgrade.TypeUpgrade.Depend, "text", 0.2f, 5);
        Upgrade depend30 = new Upgrade("Depend +30%", Upgrade.TypeUpgrade.Depend, "text", 0.3f, 1);

        //DeX
        Upgrade dex5 = new Upgrade("Dexterity +5%", Upgrade.TypeUpgrade.Dexterity, "text", 0.05f, 20);
        Upgrade dex10 = new Upgrade("Dexterity +10%", Upgrade.TypeUpgrade.Dexterity, "text", 0.1f, 10);
        Upgrade dex20 = new Upgrade("Dexterity +20%", Upgrade.TypeUpgrade.Dexterity, "text", 0.2f, 5);
        Upgrade dex30 = new Upgrade("Dexterity +30%", Upgrade.TypeUpgrade.Dexterity, "text", 0.3f, 1);

        baseUpgrades.Add(damage5);
        baseUpgrades.Add(damage10);
        baseUpgrades.Add(damage20);
        baseUpgrades.Add(damage30);

        baseUpgrades.Add(heath5);
        baseUpgrades.Add(heath10);
        baseUpgrades.Add(heath15);
        baseUpgrades.Add(heath20);

        baseUpgrades.Add(expMutiple2);
        baseUpgrades.Add(expMutiple3);

        baseUpgrades.Add(depend5);
        baseUpgrades.Add(depend10);
        baseUpgrades.Add(depend20);
        baseUpgrades.Add(depend30);

        LoadUpgrade(baseUpgrades);
        Debug.Log(baseUpgrades.Count);
        runOnce = false;
    }

    private void Update()
    {
        UpgradeOpen = UpgradeUI.activeSelf;
        if (UpgradeOpen && !runOnce)
        {
            ActiveUpgrade();
            runOnce = true;
        }
    }

    public Upgrade crUpdate1, crUpdate2, crUpdate3;

    public void SelectUpgrade()
    {
        Debug.Log(upgradeIndex);
        SetUpgrade(upgradesPicks[upgradeIndex - 1]);
        MainGame.isUpgrade = false;
        runOnce = false;
    }

    private void LoadUpgrade(List<Upgrade> baseUpgrades)
    {
        foreach (Upgrade upgradeBase in baseUpgrades)
        {
            for (int i = 0; i <= upgradeBase.CommonValue; i++)
            {
                upgrades.Add(upgradeBase);
            }
        }
    }

    private void SetUpgrade(GameObject UpgradeUi, Upgrade upgrade)
    {
        Image colorU = UpgradeUi.GetComponent<Image>();
        Image img = UpgradeUi.transform.GetChild(0).GetComponent<Image>();
        TextMeshProUGUI name = UpgradeUi.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI discription = UpgradeUi.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        Button button = UpgradeUi.transform.GetChild(3).GetComponent<Button>();
        switch (upgrade.CommonValue)
        {
            case 1:
                colorU.color = legendaryColor;
                break;
            case 2:
                colorU.color = legendaryColor;
                break;
            case 3:
                colorU.color = legendaryColor;
                break;
            case 5:
                colorU.color = epicColor;
                break;
            case 10:
                colorU.color = rareColor;
                break;
            case 20:
                colorU.color = commonColor;
                break;
        }
        name.text = upgrade.Name;
        discription.text = upgrade.Description;
        button.GetComponent<UpgradeController>().upgradesPicks = upgradesPicks;
    }

    public List<Upgrade> upgradesPicks = new List<Upgrade>();

    public void ActiveUpgrade()
    {
        var randomPick = GetRandomUpgrade();
        Debug.Log(randomPick[0] + " " + randomPick[1] + " " + randomPick[2]);
        Shuffle(upgrades);
        crUpdate1 = upgrades[randomPick[0]];
        crUpdate2 = upgrades[randomPick[1]];
        crUpdate3 = upgrades[randomPick[2]];

        //Set it into screen
        SetUpgrade(item_1, crUpdate1);
        SetUpgrade(item_2, crUpdate2);
        SetUpgrade(item_3, crUpdate3);
        upgradesPicks.Add(crUpdate1);
        upgradesPicks.Add(crUpdate2);
        upgradesPicks.Add(crUpdate3);

        //And remove it away a upgrade pool
        upgrades.Remove(crUpdate1);
        upgrades.Remove(crUpdate2);
        upgrades.Remove(crUpdate3);
    }

    public void SetUpgrade(Upgrade upgrade)
    {
        Debug.Log(upgrade);
        //lay tu player controler ve data cua nhan vat dang choi
        var playerD = PlayerController.playerData;

        switch (upgrade.type)
        {

            //1
            case Upgrade.TypeUpgrade.Heart:
                var eHeart = playerD.Heart;
                playerD.Heart += Mathf.CeilToInt(eHeart * upgrade.upgradeValue);
                break;
            //2
            case Upgrade.TypeUpgrade.Depend:
                var eDepend = playerD.Depend;
                playerD.Depend -= Mathf.Ceil(upgrade.upgradeValue * eDepend);
                break;
            //3
            case Upgrade.TypeUpgrade.Strength:
                var eStrength = playerD.Strength;
                playerD.Strength += Mathf.Ceil(eStrength * upgrade.upgradeValue);
                break;
            //4
            case Upgrade.TypeUpgrade.Dexterity:
                var eDexterity = playerD.Dexterity;
                playerD.Dexterity += Mathf.Ceil(eDexterity * upgrade.upgradeValue);
                break;
            //5
            case Upgrade.TypeUpgrade.FireCoolDown:
                var eFireCoolDown = playerD.attackCoolDown;
                playerD.attackCoolDown -= Mathf.Ceil(eFireCoolDown * upgrade.upgradeValue);
                break;
            //6
            case Upgrade.TypeUpgrade.SkillCollDown:
                var eSkillCollDown = playerD.skillCoolDown;
                playerD.skillCoolDown -= Mathf.Ceil(eSkillCollDown * upgrade.upgradeValue);
                break;
            //7
            case Upgrade.TypeUpgrade.SkillSize:
                var eSkillSize = playerD.SizeOfSkill;
                playerD.SizeOfSkill += Mathf.Ceil(eSkillSize * upgrade.upgradeValue);
                break;
            //8
            case Upgrade.TypeUpgrade.SkillDamage:
                var eSkillDamage = playerD.StrengthOfSkill;
                playerD.StrengthOfSkill += Mathf.Ceil(eSkillDamage * upgrade.upgradeValue);
                break;
            //9
            case Upgrade.TypeUpgrade.ExpMulti:
                PlayerController.expMultiple = (int)upgrade.upgradeValue;
                break;
            //10
            default:
                break;
        }
    }

    public int[] GetRandomUpgrade()
    {
        var max = upgrades.Count;
        var randomIndexes = new HashSet<int>();

        while (randomIndexes.Count < 3)
        {
            randomIndexes.Add(Random.Range(0, max));
        }

        return randomIndexes.ToArray();
    }

    void Shuffle(List<Upgrade> deck)
    {
        for (int i = 0; i < deck.Count; i++)
        {
            var temp = deck[i];
            var randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

}
