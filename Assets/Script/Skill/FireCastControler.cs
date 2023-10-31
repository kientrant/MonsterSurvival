using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCastControler : MonoBehaviour
{
    [SerializeField]
    private SkillData fireCast;

    private int damage;
    private float duration;
    private int size;

    private Animator fireCastAnimaror;

    private void Awake()
    {
        this .damage = fireCast.damage;
        this.duration = fireCast.duration;
        this.size = fireCast.size;
        gameObject.GetComponent<Transform>().localScale = new Vector2(PlayerController.playerData.SizeOfSkill, PlayerController.playerData.SizeOfSkill);
        fireCastAnimaror = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        fireCastAnimaror.speed = fireCast.speed;
        fireCastAnimaror.Play("Animation.FireCast");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D hit = collision;
        if (hit.gameObject.tag == "Enemy")
        {
            hit.gameObject.GetComponent<Enemy>().GetDamege(Mathf.CeilToInt( PlayerController.playerData.StrengthOfSkill));
        }
     }
}
