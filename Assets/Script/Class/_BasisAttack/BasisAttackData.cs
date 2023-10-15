using System.Collections;
using System.Collections.Generic;
using UnityEngine;





[CreateAssetMenu(fileName = "BasisAttackData", menuName = "My Game/Basis Attack Data")]
public class BasisAttackData : ScriptableObject
{
    public string nameBasisAttack;

    public string description;

    public string dame;

    public string speed;

    public GameObject BasisAttackPrefab;
}
