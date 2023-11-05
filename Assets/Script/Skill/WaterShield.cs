using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShield : MonoBehaviour
{
    [SerializeField]
    private SkillData skillData;

    private float duration;
    private int size;
    private float timer;

    private void Awake()
    {
        this.duration = skillData.duration;
        this.size = skillData.size;
        gameObject.GetComponent<Transform>().localScale = new Vector2(PlayerController.playerData.SizeOfSkill, PlayerController.playerData.SizeOfSkill);
    }

    private void Update()
    {
        timer += Time.deltaTime * 1;
        if (timer > duration)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D hit = collision;
        if (hit.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        else if (hit.gameObject.tag == "Player")
        {
            //nothing
        }
    }
}
