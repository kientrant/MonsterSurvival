﻿using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;

    public static bool canFire, canSkill;
    private static float timer, timer2;
    [SerializeField]
    private static float cooldownFire = 5f;
    public static float cooldownSkill = 10f;

    public GameObject playerBody;

    private Animator playerAnimator;

    [SerializeField]
    private GameObject[] weaponOfPlayer;
    [SerializeField]
    private GameObject center;
    [SerializeField]
    private GameObject skill;
    [SerializeField]
    private AudioSource basisSource;
    [SerializeField]
    private AudioSource skillSource;


    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        weaponOfPlayer = GameObject.FindGameObjectsWithTag("Weapon");
        canFire = canSkill = false;
        timer = 0;
        playerAnimator = playerBody.GetComponent<Animator>();
        cooldownFire = PlayerController.playerData.attackCoolDown;
        cooldownSkill = PlayerController.playerData.skillCoolDown;

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotate = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotate);


        cooldownFire = PlayerController.playerData.attackCoolDown;

        cooldownSkill = PlayerController.playerData.skillCoolDown;

        basisSource.volume = PlayerController.soundV;
        skillSource.volume = PlayerController.soundV;

        //Basic Attack
        if (!canFire)
        {
            if (timer > cooldownFire)
            {
                canFire = true;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (canFire)
            {
                timer = 0;
                PlayerAttack();
                canFire = false;
            }
        }

        timer += Time.deltaTime * 1;
        //Skill

        if (!canSkill)
        {
            if (timer2 > cooldownFire)
            {
                canSkill = true;
            }
        }

        if (Input.GetMouseButton(1))
        {
            if (canSkill)
            {
                timer2 = 0;
                PlayerSkill();
                canSkill = false;
            }
        }

        timer2 += Time.deltaTime * 1;
    }

    public void PlayerAttack()
    {
        //playerAnimator.Play("Player.BasisAttack");
        basisSource.Play();
        weaponOfPlayer[0].GetComponent<Weapon>().Shot();
        if (weaponOfPlayer.Length > 1) {
            for (int i = 1; i <= weaponOfPlayer.Length; i++)
            {
                weaponOfPlayer[i].GetComponent<Weapon>().Shot();
            }
        }
    }

    public void PlayerSkill()
    {
        playerAnimator.Play("Player.SkillAttack");
        skillSource.Play();
        GameObject og = Instantiate(skill, center.transform.position, Quaternion.identity);
        og.transform.parent = center.transform;
    }

}  

