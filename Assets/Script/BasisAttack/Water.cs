using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private Vector3 m_Position;
    private Camera mainCam;
    private Rigidbody2D rb;
    [SerializeField]
    private float force;

    private float deadTime = 2f;
    private float liveTime;

    public GameObject exploision;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        //Lấy main cam object
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //Lấy vị trí chuột
        m_Position = mainCam.ScreenToWorldPoint(Input.mousePosition);
        //lấy hướng cần bắn đạn
        Vector3 rotation = m_Position - transform.position;

        //Chuyển thành độ quay
        float rotate = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotate + 90);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Collider2D hit = collision;
        if (hit.gameObject.tag == "Enemy")
        {
            hit.gameObject.GetComponent<Enemy>().GetDamege(10);
            //Instantiate(exploision, transform.position, transform.rotation);
        }
        else
        {
            //Instantiate(exploision, transform.position, transform.rotation);
        }
    }
}
