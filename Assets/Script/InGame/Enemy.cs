using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private GameObject target;
    [SerializeField]
    private float speed = 3f;
    private float distance;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sR;

    [SerializeField]
    private GameObject coin;
    [SerializeField]
    private GameObject exp;
    [SerializeField]
    private GameObject DropPool;

    private static int baseHeath = 10;
    private int thisHeath ;

    private bool canAttack;
    private float timer;
    private float delayAttack = 2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sR = GetComponent<SpriteRenderer>();
        thisHeath = 5 * baseHeath;
    }



    // Update is called once per frame
    private void Update()
    {

    }

    private void FixedUpdate()
    {

        DetectPlayer();
    }

    private void DetectPlayer()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        if (target != null)
        {
            distance = Vector2.Distance(transform.position, target.transform.position);
            //Debug.Log(distance.ToString());
            Vector2 direction = target.transform.position - transform.forward;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            //Debug.Log(angle);
            if (distance > 0.5f)
            {
                //transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
                rb.MovePosition(Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime));
            }

            if (transform.position.x > target.transform.position.x)
            {
                sR.flipX = true;
            }
            else
            {
                sR.flipX = false;
            }
        }
    }

    //trả về this heath objects
    public int GetDamege(int hitDamage)
    {
        
        thisHeath -= hitDamage;
        if (thisHeath <= 0)
        {
            Die();
        }
        return thisHeath;
    }

    private int GetMonsterLevel ()
    {
        int level = 0;
        String monsterName = this.gameObject.name;

        level = int.Parse(monsterName.Split('_')[1]); 

        return level;

    }

    private void DropCoin(int level)
    {
        int numberOfDrop =  new System.Random().Next(1 , level*2);
        for (int i = 0; i <= numberOfDrop; i++)
        {
            GameObject op = Instantiate(coin, this.transform.position, Quaternion.identity);
            op.transform.parent = DropPool.transform;
        }
    }

    private void DropExp(int level)
    {
        int numberOfDrop = new System.Random().Next(1, level);
        for (int i = 0; i <= numberOfDrop; i++)
        {
            GameObject op = Instantiate(exp, this.transform.position, Quaternion.identity);
            op.transform.parent = DropPool.transform;
        }
    }

    private void Die()
    {
        int monsterLevel = GetMonsterLevel();
        DropCoin(monsterLevel);
        DropExp(monsterLevel);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Collider2D hit = collision.collider;
        if (hit.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Hit");
            anim.SetBool("Attack", true);
            if (!canAttack)
            {
                if (timer > delayAttack)
                {
                    canAttack = true;
                }
            }
                if (canAttack)
                {
                    timer = 0;
                    hit.gameObject.GetComponent<PlayerController>().GetDamege(GetMonsterLevel() * 10);
                    canAttack = false;
                }

            timer += Time.deltaTime * 5;
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("Attack", false);
    }

}
