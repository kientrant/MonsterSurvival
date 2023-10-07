using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DropEffect : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 0.1f;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        //this.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-5,5), Random.Range(-5, 5)));
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        distance = Vector2.Distance(this.transform.position, target.transform.position);
        Vector2 direction = target.transform.position - transform.forward;

        Debug.Log(target.transform.position);
        direction.Normalize();
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        //Debug.Log(angle);
        if (distance < 5f)
        {
            //transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
            transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

}
