using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamOffSet : MonoBehaviour
{
    public GameObject player; //'public' creates a variable that can be set in the unity editor
    private Vector3 offset; /*variable recording the offset position of the camera, not visible in unity editor*/

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        //record difference between camera and player position
        //transform.position = position of gameObject this script is attached to   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
