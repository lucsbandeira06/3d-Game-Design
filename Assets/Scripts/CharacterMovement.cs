using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public CharacterController controller;
    public Transform cam;

    public float speed = 18f;
    float gravity = 9.87f;
    public float jumpSpeed = 6f;
    public Vector3 jumpDirection = Vector3.zero;
    
    public float turnSmoothTime = 0.1f;
    float turnSmoothvelocity;


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothvelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

             /*JUMP*/
        if(controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            jumpDirection.y = jumpSpeed;
        }
        else if(!controller.isGrounded)
        {
            jumpDirection.y -= gravity * Time.deltaTime;
        }
        }
    }
}
