using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject[] bullet;
    private GameObject parentObject;
    private PlayerController playerController;
    [SerializeField]
    private Transform crosshairTrans;
    // Start is called before the first frame update
    void Start()
    {
        parentObject = GameObject.FindGameObjectWithTag("Player");
        playerController = parentObject.GetComponent<PlayerController>();
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

    public void Shot(int weaponIndex)   
    {
     
        GameObject og = Instantiate(bullet[0], transform.position, Quaternion.Euler(0,0, transform.rotation.z));
    }
}
