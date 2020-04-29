using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region
    //look Variables
    public Camera camera;

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


<<<<<<< HEAD
<<<<<<< HEAD
    #endregion

    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
=======
    void Start()
=======
    public HealthBar healthBar;

<<<<<<< HEAD

=======
>>>>>>> parent of f5e70b3... 0.2.1
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        currentHealth = maxHealth;
    }

    void Update()
>>>>>>> parent of f5e70b3... 0.2.1
    {
>>>>>>> parent of f5e70b3... 0.2.1
        Cursor.lockState = CursorLockMode.Locked;
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
        if (characterController.isGrounded)
        {
            Vector3 forwardMovement = transform.forward * Input.GetAxisRaw("Vertical");
            Vector3 strafeMovement = transform.right * Input.GetAxisRaw("Horizontal");
            moveDirection = (forwardMovement + strafeMovement).normalized * movementSpeed;

            if (Input.GetKey(KeyCode.LeftShift)){
                movementSpeed = runSpeed;
            } else {
                movementSpeed = walkSpeed;
            }

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
            
        }

        moveDirection.y -= gravityForce * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> parent of f5e70b3... 0.2.1
=======
>>>>>>> parent of f5e70b3... 0.2.1
=======
>>>>>>> parent of f5e70b3... 0.2.1
}
