using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAim : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;

    public bool canFire;
    private float timer;
    [SerializeField]
    private float delayFire;

    private GameObject[] weaponOfPlayer;

    GameObject playerBody;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        weaponOfPlayer = GameObject.FindGameObjectsWithTag("Weapon");
        playerBody = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation =  mousePos - transform.position;

        float rotate = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation =  Quaternion.Euler(0,0 ,rotate);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > delayFire)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            foreach (var weapon in weaponOfPlayer)
            {
                weapon.GetComponent<Weapon>().Shot(0);
                Debug.Log(weapon);
            }
        }
    }
}
