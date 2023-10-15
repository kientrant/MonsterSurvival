using System.Collections;
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
    public static float cooldownFire = 5f;
    public static float cooldownSkill = 50f;

    public GameObject playerBody;

    private Animator playerAnimator;

    private GameObject weaponOfPlayer;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        weaponOfPlayer = GameObject.FindGameObjectWithTag("Weapon");
        canFire = canSkill = false;
        timer = 0;
        playerAnimator = playerBody.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotate = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotate);

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

        timer += Time.deltaTime * 5;
    }

    public void PlayerAttack()
    {
        playerAnimator.Play("Player.BasisAttack");
        weaponOfPlayer.GetComponent<Weapon>().Shot();
    }

}  

