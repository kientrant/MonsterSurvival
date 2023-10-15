using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static SkillData skillData;
    public static BasisAttackData basisAttackData;

    private GameObject bullet;
    private GameObject skill;

    private GameObject parentObject;
    private PlayerController playerController;
    [SerializeField]
    private Transform crosshairTrans;

    // Start is called before the first frame update
    void Start()
    {
        parentObject = GameObject.FindGameObjectWithTag("Player");
        playerController = parentObject.GetComponent<PlayerController>();
        bullet = PlayerController.playerData.basisAttack;
        skill = PlayerController.playerData.Skill;
    }

    // Update is called once per frame
    void Update()
    {
        if (crosshairTrans.position.x < parentObject.transform.position.x)
        {
            playerController.Flip(true);
        } else
        {
            playerController.Flip(false);
        }
    }

    public void Shot()   
    {
     
        GameObject og = Instantiate(bullet, transform.position, Quaternion.Euler(0,0, transform.rotation.z));
    }
}
