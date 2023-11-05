using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockRotate : MonoBehaviour
{
    private float damage;
    private float size;


    // Start is called before the first frame update
    void Start()
    {
        damage = PlayerController.playerData.StrengthOfSkill;
        size = PlayerController.playerData.SizeOfSkill;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D hit = collision;
        if (hit.gameObject.tag == "Enemy")
        {
            hit.gameObject.GetComponent<Enemy>().GetDamege((int)damage);
        }
    }
}
