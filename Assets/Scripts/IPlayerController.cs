using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPlayerController : MonoBehaviour
{
    public CharacterController controller;

    public Camera camaraPrimeraPersona;

    public float speed;

    public float gravity = -9.8f;

    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;
    void Start()
    {


        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

   
        Vector3 move = (transform.right * x + transform.forward * z);

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
