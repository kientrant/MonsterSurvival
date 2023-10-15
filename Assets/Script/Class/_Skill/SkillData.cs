using UnityEngine;


[CreateAssetMenu(fileName = "SkillData", menuName = "My Game/Skill Data")]
public class SkillData : ScriptableObject
{
    public string nameSkill;

    public string description;

    public int damage;

    public float duration;

    public int size;

    public GameObject SkillPrefab;
}
