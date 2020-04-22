﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //look Variables
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private CharacterController characterController;

    private float mouseX;
    private float mouseY;

    [Range(0.0f, 10.0f)]
    public float lookSensitivity = 1;

    //movement variables

    [SerializeField]
    private float walkSpeed = 5;
    [SerializeField]
    private float runSpeed = 8;

    private float movementSpeed = 0.0f;
    private float jumpForce = 5.0f;
    private float gravityForce = 9.807f;

    private Vector3 moveDirection;

    //weapon variables
    
    private bool isEquipped = false;

    [SerializeField]
    private GameObject m16;

    private RaycastHit hit;



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Movement();
        Weapon();
    }

    void Rotate()
        {
            // get input
            mouseX += Input.GetAxisRaw("Mouse X") * lookSensitivity;
            mouseY += Input.GetAxisRaw("Mouse Y") * lookSensitivity;

            //apply input.
            transform.localRotation = Quaternion.Euler(Vector3.up * mouseX);
            camera.transform.localRotation = Quaternion.Euler(Vector3.left * mouseY);
            mouseY = Mathf.Clamp(mouseY, -90.0f, 90.0f);
        }

    void Movement()
        {
            //if the player is touching ground
            if (characterController.isGrounded)
            {
                // recieve input for movement
                Vector3 forwardMovement = transform.forward * Input.GetAxisRaw("Vertical");
                Vector3 strafeMovement = transform.right * Input.GetAxisRaw("Horizontal");
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    movementSpeed = runSpeed;
                }
                else
                {
                    movementSpeed = walkSpeed;
                }
                //convert input to vector 3
                moveDirection = (forwardMovement + strafeMovement).normalized * movementSpeed;
                //if player jumps
                if (Input.GetButtonDown("Jump"))
                {
                    //jump
                    moveDirection.y = jumpForce;
                }
            }
            //caluclate gravity and modify movement vector
            moveDirection.y -= gravityForce * Time.deltaTime;
            //move the player with movement vector.
            characterController.Move(moveDirection * Time.deltaTime);

        }

    void Weapon()
    {   //if click e
        if (Input.GetKey(KeyCode.E))
        {   //shoot a ray
            var UseItemRay = new Ray(camera.transform.position, camera.transform.forward);
            //if the ray hits something
            if (Physics.Raycast(UseItemRay, out hit, 10))
            {   // & if it hits the weapon Pickup
                if (hit.collider.name == "m16_Pickup")
                {   // & nothings equipped
                    if (!isEquipped)
                    {   // give weapon (set weapon active)
                        m16.SetActive(true);
                        hit.collider.gameObject.SetActive(false);
                        isEquipped = true;
                    }
                }
            }
        }
    }

}
