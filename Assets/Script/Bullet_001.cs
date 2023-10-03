﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_001 : MonoBehaviour
{
    private Vector3 m_Position;
    private Camera mainCam;
    private Rigidbody2D rb;
    [SerializeField]
    private float force;

    private float deadTime = 2f;
    private float liveTime;
    // Start is called before the first frame update
    void Start()
    {
        //Lấy main cam object
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        //Lấy vị trí chuột
        m_Position = mainCam.ScreenToWorldPoint(Input.mousePosition);
        //lấy hướng cần bắn đạn
        Vector3 rotation = m_Position - transform.position;
        //Thêm lực vào viên đạn bay
        rb.velocity = new Vector2(rotation.x, rotation.y).normalized * force;

        //Chuyển thành độ quay
        float rotate = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0 ,rotate);
    }

    // Update is called once per frame
    void Update()
    {
        liveTime += Time.deltaTime;
        //Debug.Log(liveTime);
        if (liveTime > deadTime){
            Destroy(gameObject);
        }
    }

    private void OnCollision2D(Collision2D collision)
    {
        Collider2D hit = collision.collider;
        if (hit.gameObject.CompareTag("Enemy"))
        {
            Destroy(hit);
        }
    }
}
