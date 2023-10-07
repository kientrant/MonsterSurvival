using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "My Game/Player Data") ]
public class PlayerData : ScriptableObject
{
    public string PlayerName;

    public string Description;

    public GameObject classModel;

    public int Heart = 100;

    public float Depend = 1f;

    public float Strength = 10f;

    public float Dexterity = 5f;

    public float SizeOfSkill = 1f;

    public float StrengthOfSkill = 30f;

    private GameObject Skill;

}
