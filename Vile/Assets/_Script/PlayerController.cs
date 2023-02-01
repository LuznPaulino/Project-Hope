using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 playerVelocity;
    public float Speed = 2.0f;
    private bool PlayerGrounded;
    private float Gravity = -9.81f;

    void Update(){
        PlayerGrounded = controller.isGrounded;
        if(PlayerGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y=0f;
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        controller.Move(movement * Time.deltaTime * Speed);

        if(movement != Vector3.zero)
        {
            gameObject.transform.forward = movement;
        }

       playerVelocity.y += Gravity * Time.deltaTime;
       controller.Move(playerVelocity * Time.deltaTime);
    }
}
