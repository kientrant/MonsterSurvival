using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowControler : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        this.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}
