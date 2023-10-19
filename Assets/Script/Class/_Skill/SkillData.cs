using UnityEngine;


[CreateAssetMenu(fileName = "SkillData", menuName = "My Game/Skill Data")]
public class SkillData : ScriptableObject
{
    public string nameSkill;

    public string description;

    public int damage;

    [Range(1f,100f)]
    public float duration;
    [Range(1f, 5f)]
    public int size;
    [Range(1f, 5f)]
    public float speed;
}
