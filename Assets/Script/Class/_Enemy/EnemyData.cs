using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(fileName = "EnemyData", menuName = "My Game/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string nameEnemy;

    public string description;

    public int heath;

    public int damage;

    public float speed;

    public GameObject EnemyPretab;
}
