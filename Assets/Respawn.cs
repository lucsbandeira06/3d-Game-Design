using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawn;
    private Rigidbody r;

    private void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -5f) /*fall below -5 on y axis, perform this code*/
        {
            transform.position = respawn.position;
            r.velocity = Vector3.zero;
        }
        
    }
}